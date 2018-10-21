using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Tapir.Core;
using Tapir.Models;

namespace Tapir.Services
{
    public class AccountService : IAccountService
    {
        private UserManager<TapirUser> userManager;
        private SignInManager<TapirUser> signInManager;
        private IConfiguration configuration;

        public AccountService(
            UserManager<TapirUser> userManager,
            SignInManager<TapirUser> signInManager,
            IConfiguration configuration
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public async Task<String> CreateToken(LoginDTO login)
        {            
            if (!Validator.TryValidateObject(login, new ValidationContext(login), new List<ValidationResult>()))
            {
                throw new ArgumentException("LoginDTO instance failed validation");
            }
            var loginResult = await signInManager.PasswordSignInAsync(
                login.Username, login.Password, isPersistent: false, lockoutOnFailure: false);
            if (!loginResult.Succeeded)
            {
                return null;
            }
            var user = await userManager.FindByNameAsync(login.Username);
            return GetToken(user);
        }

        public async Task<string> RefreshToken(ClaimsPrincipal currentUser)
        {
            if(currentUser == null)
            {
                throw new ArgumentException("Parameter currentUser cannot be null");
            }
            var user = await userManager.FindByNameAsync(
                currentUser.Identity.Name ??
                currentUser.Claims.Where(c => c.Properties.ContainsKey("unique_name"))
                    .Select(c => c.Value).FirstOrDefault());
            return GetToken(user);
        }

        public async Task<string> Register(RegistrationDTO registration)
        {
            var user = new TapirUser
            {
                UserName = registration.Username,
                FirstNames = registration.FirstNames,
                LastName = registration.LastName,
                Email = registration.Email
            };
            var identityResult = await this.userManager.CreateAsync(user, registration.Password);
            if (identityResult.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return GetToken(user);
            }
            else
            {
                Console.WriteLine(identityResult);
                throw new ArgumentException("New User creation failed.");
            }
        }

        private String GetToken(IdentityUser user)
        {
            var utcNow = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
            };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.GetValue<String>("Tokens:Key")));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: utcNow,
                expires: utcNow.AddSeconds(this.configuration.GetValue<int>("Tokens:Lifetime")),
                audience: this.configuration.GetValue<String>("Tokens:Audience"),
                issuer: this.configuration.GetValue<String>("Tokens:Issuer")
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Tapir.Core;

namespace Tapir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> CreateToken(LoginDTO login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var token = await accountService.CreateToken(login);
                if(token != null)
                {
                    return Ok(token);
                }
                else
                {
                    return BadRequest();
                }
                
            } catch (ArgumentException exc)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        [Route("refreshtoken")]
        public async Task<IActionResult> RefreshToken()
        {
            try
            {
                var token = await accountService.RefreshToken(User);
                return Ok(token);
            } catch (ArgumentException exc)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegistrationDTO registration)
        {
            Console.WriteLine("Starting");
            if(!ModelState.IsValid)
            {
                Console.WriteLine("Invalid state");
                return BadRequest(ModelState);
            }
            try
            {
                Console.WriteLine("Trying");
                var token = await accountService.Register(registration);
                return Ok(token);
            } catch (ArgumentException exc)
            {
                Console.WriteLine("Exception");
                return BadRequest();
            }
        }        
    }
}

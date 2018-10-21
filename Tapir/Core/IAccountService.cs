using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Tapir.Core
{
    public interface IAccountService
    {
        Task<String> CreateToken(LoginDTO login);
        Task<String> RefreshToken(ClaimsPrincipal currentUser);
        Task<String> Register(RegistrationDTO registration);
    }
}

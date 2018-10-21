using System;
using System.ComponentModel.DataAnnotations;

namespace Tapir.Core
{
    public class LoginDTO
    {
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }
    }
}

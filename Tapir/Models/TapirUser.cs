using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Tapir.Models
{
    public class TapirUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public String FirstNames { get; set; }
        [Required]
        [StringLength(100)]
        public String LastName { get; set; }
    }
}

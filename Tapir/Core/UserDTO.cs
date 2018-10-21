using System.ComponentModel.DataAnnotations;

namespace Tapir.Core
{
    public class UserDTO
    {
        public int? Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstNames { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}

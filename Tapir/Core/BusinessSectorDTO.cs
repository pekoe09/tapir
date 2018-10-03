using System.ComponentModel.DataAnnotations;

namespace Tapir.Core
{
    public class BusinessSectorDTO
    {
        public int? Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Tapir.Core
{
    public class CompanyDto
    {
        public int? ID { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string ShortName { get; set; }
    }
}

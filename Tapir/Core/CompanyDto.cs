using System.ComponentModel.DataAnnotations;

namespace Tapir.Core
{
    public class CompanyDto
    {
        public int? Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public string BusinessId { get; set; }
        [Required]
        public int SectorId { get; set; }
        public string SectorCode { get; set; }
        public string SectorName { get; set; }
        public string InsuranceNumber { get; set; }
        [Required]
        public string BankAccount { get; set; }
    }
}

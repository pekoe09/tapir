using System.ComponentModel.DataAnnotations;
using Tapir.Core;

namespace Tapir.Models
{
    public class BusinessSector : EntityBase
    {
        [Required]
        [StringLength(10, ErrorMessage = "Business sector code cannot exceed 10 characters")]
        public string Code { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Business sector name cannot exceed 100 characters")]
        public string Name { get; set; }

        internal BusinessSectorDTO getDTO()
        {
            return new BusinessSectorDTO()
            {
                Id = this.ID,
                Code = this.Code,
                Name = this.Name
            };
        }
        
        internal static BusinessSector Hydrate(BusinessSectorDTO dto)
        {
            return new BusinessSector()
            {
                ID = dto.Id,
                Code = dto.Code,
                Name = dto.Name
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tapir.Core;

namespace Tapir.Models
{
    public class Company : EntityBase
    {        
        [Required]
        [StringLength(100, ErrorMessage = "Company full name length cannot exceed 100 characters.")]
        public string FullName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Company short name length cannot exceed 20 characters.")]
        public string ShortName { get; set; }
        public ICollection<Employment> Employments { get; set; }

        internal CompanyDto getDTO()
        {
            return new CompanyDto()
            {
                ID = this.ID,
                FullName = this.FullName,
                ShortName = this.ShortName
            };
        }

        internal static Company Hydrate(CompanyDto dto)
        {
            return new Company()
            {
                ID = dto.ID,
                FullName = dto.FullName,
                ShortName = dto.ShortName                
            };
        }
    }
}

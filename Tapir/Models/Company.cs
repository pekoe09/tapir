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
        [Required]
        [StringLength(20, ErrorMessage = "Company business id length cannot exceed 20 characters.")]
        public string BusinessId { get; set; }
        public List<Address> Addresses { get; set; }
        public BusinessSector Sector { get; set; }
        [StringLength(30, ErrorMessage = "Company insurance number length cannot exceed 30 characters")]
        public string InsuranceNumber { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Company bank account number length cannot exceed 30 characters")]
        public string BankAccount { get; set; }
        public ICollection<Employment> Employments { get; set; }

        internal CompanyDTO getDTO()
        {
            return new CompanyDTO()
            {
                Id = this.ID,
                FullName = this.FullName,
                ShortName = this.ShortName,
                BusinessId = this.BusinessId,
                SectorId = (int)this.Sector.ID,
                SectorCode = this.Sector.Code,
                SectorName = this.Sector.Name,
                InsuranceNumber = this.InsuranceNumber,
                BankAccount = this.BankAccount
            };
        }

        internal static Company Hydrate(CompanyDTO dto)
        {
            Company company = new Company()
            {
                ID = dto.Id,
                FullName = dto.FullName,
                ShortName = dto.ShortName,
                BusinessId = dto.BusinessId,
                Sector = new BusinessSector()
                {
                    ID = dto.SectorId,
                    Code = dto.SectorCode,
                    Name = dto.SectorName
                },
                InsuranceNumber = dto.InsuranceNumber,
                BankAccount = dto.BankAccount
            };
            return company;
        }
    }
}

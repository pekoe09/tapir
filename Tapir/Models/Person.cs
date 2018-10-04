using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tapir.Core;

namespace Tapir.Models
{
    public class Person : EntityBase
    {
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First names cannot be longer than 50 characters")]
        public string FirstNames { get; set; }
        public string SSN { get; set; }
        [Required]
        public Address Address { get; set; }
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
        public string Email { get; set; }
        [StringLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters")]
        public string Phone { get; set; }
        [StringLength(20, ErrorMessage = "Language cannot be longer than 20 characters")]
        public string Language { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Citizenship cannot be longer than 50 characters")]
        public string Citizenship { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Profession cannot be longer than 50 characters")]
        public string Profession { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "IBAN cannot be longer than 20 characters")]
        public string IBAN { get; set; }
        [Required]
        public bool IsOwner { get; set; }
        [Range(minimum: 0.0, maximum: 100.0)]
        public double? OwnershipSelf { get; set; }
        [Range(minimum: 0.0, maximum: 100.0)]
        public double? VotesSelf { get; set; }
        [Range(minimum: 0.0, maximum: 100.0)]
        public double? OwnershipWithFamily { get; set; }
        [Range(minimum: 0.0, maximum: 100.0)]
        public double? VotesWithFamily { get; set; }
        [StringLength(100, ErrorMessage = "Company position cannot be longer than 100 characters")]
        public string PositionInCompany { get; set; }
        [StringLength(100, ErrorMessage = "Regular place of employment cannot be longer than 100 characters")]
        public string PlaceOfRegularEmployment { get; set; }
        [StringLength(100, ErrorMessage = "Regular employment city cannot be longer than 100 characters")]
        public string CityOfRegularEmployment { get; set; }
        public Address RegularEmploymentAddress { get; set; }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstNames;
            }
        }
        public ICollection<Employment> Employments { get; set; }

        internal PersonDTO getDTO()
        {
            return new PersonDTO
            {
                ID = this.ID,
                LastName = this.LastName,
                FirstNames = this.FirstNames,
                SSN = this.SSN,
                Address = this.Address.GetDTO(),
                Email = this.Email,
                Phone = this.Phone,
                Language = this.Language,
                Citizenship = this.Citizenship,
                Profession = this.Profession,
                IBAN = this.IBAN,
                IsOwner = this.IsOwner,
                OwnershipSelf = this.OwnershipSelf,
                VotesSelf = this.VotesSelf,
                OwnershipWithFamily = this.OwnershipWithFamily,
                VotesWithFamily = this.VotesWithFamily,
                PositionInCompany = this.PositionInCompany,
                PlaceOfRegularEmployment = this.PlaceOfRegularEmployment,
                CityOfRegularEmployment = this.CityOfRegularEmployment,
                RegularEmploymentAddress = this.RegularEmploymentAddress.GetDTO()
            };
        }

        internal static Person Hydrate(PersonDTO dto)
        {
            return new Person()
            {
                ID = dto.ID,
                LastName = dto.LastName,
                FirstNames = dto.FirstNames,
                SSN = dto.SSN,
                Address = Address.Hydrate(dto.Address),
                Email = dto.Email,
                Phone = dto.Phone,
                Language = dto.Language,
                Citizenship = dto.Citizenship,
                Profession = dto.Profession,
                IBAN = dto.IBAN,
                IsOwner = dto.IsOwner,
                OwnershipSelf = dto.OwnershipSelf,
                VotesSelf = dto.VotesSelf,
                OwnershipWithFamily = dto.OwnershipWithFamily,
                VotesWithFamily = dto.VotesWithFamily,
                PositionInCompany = dto.PositionInCompany,
                PlaceOfRegularEmployment = dto.PlaceOfRegularEmployment,
                CityOfRegularEmployment = dto.CityOfRegularEmployment,
                RegularEmploymentAddress = Address.Hydrate(dto.RegularEmploymentAddress)
            };
        }
    }
}

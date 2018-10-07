using System;
using System.ComponentModel.DataAnnotations;

namespace Tapir.Core
{
    public class PersonDTO
    {
        public int? ID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstNames { get; set; }
        public string SSN { get; set; }
        public AddressDTO Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Language { get; set; }
        public string Citizenship { get; set; }
        public string Profession { get; set; }
        public string IBAN { get; set; }
        public bool IsOwner { get; set; }
        public double? OwnershipSelf { get; set; }
        public double? VotesSelf { get; set; }
        public double? OwnershipWithFamily { get; set; }
        public double? VotesWithFamily { get; set; }
        public string PositionInCompany { get; set; }
        public string PlaceOfRegularEmployment { get; set; }
        public string CityOfRegularEmployment { get; set; }
        public AddressDTO RegularEmploymentAddress { get; set; }
    }
}

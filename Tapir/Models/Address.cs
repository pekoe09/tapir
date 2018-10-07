using System.ComponentModel.DataAnnotations;
using Tapir.Core;

namespace Tapir.Models
{
    public class Address : EntityBase
    {
        [StringLength(100, ErrorMessage = "Street address (row 1) length cannot exceed 100 characters")]
        public string Street1 { get; set; }
        [StringLength(100, ErrorMessage = "Street address (row 2) length cannot exceed 100 characters")]
        public string Street2 { get; set; }
        [StringLength(20, ErrorMessage = "ZIP code length cannot exceed 20 characters")]
        public string Zip { get; set; }
        [StringLength(50, ErrorMessage = "City length cannot exceed 50 characters")]
        public string City { get; set; }
        [StringLength(50, ErrorMessage = "Country length cannot exceed 50 characters")]
        public string Country { get; set; }

        internal AddressDTO GetDTO()
        {
            return new AddressDTO()
            {
                Id = this.ID,
                Street1 = this.Street1,
                Street2 = this.Street2,
                Zip = this.Zip,
                City = this.City,
                Country = this.Country
            };
        }

        static internal Address Hydrate(AddressDTO dto)
        {
            return new Address()
            {
                ID = dto.Id,
                Street1 = dto.Street1,
                Street2 = dto.Street2,
                Zip = dto.Zip,
                City = dto.City,
                Country = dto.Country
            };
        }
    }
}
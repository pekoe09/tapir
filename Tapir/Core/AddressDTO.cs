using System.ComponentModel.DataAnnotations;

namespace Tapir.Core
{
    public class AddressDTO
    {
        public int? Id { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
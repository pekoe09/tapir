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
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }
}

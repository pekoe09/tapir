using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tapir.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First names cannot be longer than 50 characters")]
        public string FirstNames { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstNames;
            }
        }
        public ICollection<Employment> Employments { get; set; }
    }
}

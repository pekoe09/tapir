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

        internal PersonDTO getDTO()
        {
            return new PersonDTO
            {
                ID = this.ID,
                LastName = this.LastName,
                FirstNames = this.FirstNames,
                DOB = this.DOB
            };
        }

        internal static Person Hydrate(PersonDTO dto)
        {
            return new Person()
            {
                ID = dto.ID,
                LastName = dto.LastName,
                FirstNames = dto.FirstNames,
                DOB = dto.DOB
            };
        }
    }
}

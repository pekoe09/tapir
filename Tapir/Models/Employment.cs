using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tapir.Models
{
    public class Employment
    {
        public int ID { get; set; }
        [Required]
        public int CompanyID { get; set; }
        [Required]
        public int PersonID { get; set; }

        public Company Company { get; set; }
        public Person Person { get; set; }
    }
}

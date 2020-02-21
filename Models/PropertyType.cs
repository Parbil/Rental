using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class PropertyType
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="Type Name")]
        public string TypeName { get; set; }
    }
}

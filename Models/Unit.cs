using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class Unit
    {
        public int Id { get; set; }
        [Display(Name = "Code")]
        [Required]
        public string Code { get; set; }
        [Display(Name = "Property")]
        [Required]
        public int PropertyId { get; set; }
        [Display(Name = "Unit Type")]
        [Required]
        public int UnitTypeId { get; set; }
        [Display(Name = "Owner Contact")]
        [Required]
        public int PartyId { get; set; }

        public Property Property { get; set; }
        public UnitType UnitType { get; set; }
        public Party Party { get; set; }
    }
}

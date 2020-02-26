using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class Party
    {
        public int Id { get; set; }
        [Display(Name = "Code")]
        public string Code { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }
        [Display(Name = "Is Employee")]
        public Boolean IsEmployee { get; set; }
        [Display(Name = "Is User")]
        public Boolean IsUser { get; set; }
        [Display(Name = "Is Supplier")]
        public Boolean IsSupplier { get; set; }
        [Display(Name = "Is Customer")]
        public Boolean IsCustomer { get; set; }
        [Display(Name = "Contact No")]
        [Required]
        public string ContactNo { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

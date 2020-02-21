using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class Property
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [Display(Name = "PIN")]
        public int Pin { get; set; }
        [Required]
        [Display(Name = "Contact Person")]
        public int PartyId{ get; set; }
        [Required]
        [Display(Name = "Property Type")]
        public int PropertyTypeId { get; set; }
        public Country Country { get; set; }
        public Party Party { get; set; }
        public PropertyType propertyType { get; set; }
        [Column(TypeName ="decimal(12 ,9)")]
        [DisplayFormat(DataFormatString = "{0:##0.#########}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^\d{0,3}.?\d{0,9}$", ErrorMessage = "Invalid Value; Maximum Nine Decimal Points.")]
        public Decimal? Lattitude { get; set; }
        [Column(TypeName = "decimal(12 ,9)")]
        [DisplayFormat(DataFormatString = "{0:##0.#########}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^\d{0,3}.?\d{0,9}$", ErrorMessage = "Invalid Value; Maximum Nine Decimal Points.")]
        public Decimal? Longitude { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public enum STATUS
    {
        OCCUPIED,
        RESERVED,
        AVAILABLE,
    }
    public class Tenancy
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Party")]
        public int PartyId { get; set; }
        [Required]
        [Display(Name = "Unit")]
        public int UnitId { get; set; }
        [Required]
        [Display(Name = "Unit Price")]
        public int UnitPriceId { get; set; }
        [Required]
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }
        [Required]
        [Display(Name = "Status")]
        public STATUS Status { get; set; }
        [Required]
        [Display(Name = "From Date")]
        public DateTime FromDate{ get; set; }
        [Display(Name = "To Date")]
        [Required]
        public DateTime ToDate { get; set; }
        [Column(TypeName = "decimal(15 ,3)")]
        [DisplayFormat(DataFormatString = "{0:###########0.###}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^\d{0,12}.?\d{0,3}$", ErrorMessage = "Invalid Value; Maximum Three Decimal Points.")]
        [Display(Name = "Advance Amount")]
        public Decimal? AdvanceAmount { get; set; }

        public Unit Unit { get; set; }
        public Party Party { get; set; }
        public UnitPrice UnitPrice { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{

    public enum PERIODICITY
    {
        HOUR,
        DAY,
        WEEK,
        MONTH
    }

    public class UnitPrice
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Period")]
        public int Period { get; set; }
        [Required]
        [Display(Name = "Periodicity")]
        public PERIODICITY Periodicity { get; set; }
        [Column(TypeName = "decimal(15 ,3)")]
        [DisplayFormat(DataFormatString = "{0:###########0.###}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^\d{0,12}.?\d{0,3}$", ErrorMessage = "Invalid Value; Maximum Three Decimal Points.")]
        [Required]
        [Display(Name = "Price")]
        public Decimal? Price { get; set; }
        [Required]
        [Display(Name = "Unit")]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}

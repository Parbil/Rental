using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rental.Data;
using Rental.Models;

namespace Rental.Pages.UnitPrices
{
    public class DeleteModel : PageModel
    {
        private readonly Rental.Data.ApplicationDbContext _context;

        public DeleteModel(Rental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UnitPrice UnitPrice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UnitPrice = await _context.UnitPrices
                .Include(u => u.Unit).FirstOrDefaultAsync(m => m.Id == id);

            if (UnitPrice == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UnitPrice = await _context.UnitPrices.FindAsync(id);

            if (UnitPrice != null)
            {
                _context.UnitPrices.Remove(UnitPrice);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { UnitId = UnitPrice.UnitId });
        }
    }
}

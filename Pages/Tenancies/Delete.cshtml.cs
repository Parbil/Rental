using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rental.Data;
using Rental.Models;

namespace Rental.Pages.Tenancies
{
    public class DeleteModel : PageModel
    {
        private readonly Rental.Data.ApplicationDbContext _context;

        public DeleteModel(Rental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tenancy Tenancy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tenancy = await _context.Tenancy
                .Include(t => t.Party)
                .Include(t => t.Unit)
                .Include(t => t.UnitPrice).FirstOrDefaultAsync(m => m.Id == id);

            if (Tenancy == null)
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

            Tenancy = await _context.Tenancy.FindAsync(id);

            if (Tenancy != null)
            {
                _context.Tenancy.Remove(Tenancy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

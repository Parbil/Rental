using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rental.Data;
using Rental.Models;

namespace Rental.Pages.PropertyTypes
{
    public class DeleteModel : PageModel
    {
        private readonly Rental.Data.ApplicationDbContext _context;

        public DeleteModel(Rental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PropertyType PropertyType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PropertyType = await _context.PropertyTypes.FirstOrDefaultAsync(m => m.id == id);

            if (PropertyType == null)
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

            PropertyType = await _context.PropertyTypes.FindAsync(id);

            if (PropertyType != null)
            {
                _context.PropertyTypes.Remove(PropertyType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

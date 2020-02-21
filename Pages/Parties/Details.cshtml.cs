using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rental.Data;
using Rental.Models;

namespace Rental.Pages.Parties
{
    public class DetailsModel : PageModel
    {
        private readonly Rental.Data.ApplicationDbContext _context;

        public DetailsModel(Rental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Party Party { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Party = await _context.Parties.FirstOrDefaultAsync(m => m.Id == id);

            if (Party == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

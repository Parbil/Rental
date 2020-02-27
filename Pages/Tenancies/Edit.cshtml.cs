using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rental.Data;
using Rental.Models;

namespace Rental.Pages.Tenancies
{
    public class EditModel : PageModel
    {
        private readonly Rental.Data.ApplicationDbContext _context;

        public EditModel(Rental.Data.ApplicationDbContext context)
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
           ViewData["PartyId"] = new SelectList(_context.Parties, "Id", "Address");
           ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Code");
           ViewData["UnitPriceId"] = new SelectList(_context.UnitPrices, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tenancy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenancyExists(Tenancy.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TenancyExists(int id)
        {
            return _context.Tenancy.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rental.Data;
using Rental.Models;

namespace Rental.Pages.Units
{
    public class CreateModel : PageModel
    {
        private readonly Rental.Data.ApplicationDbContext _context;

        public CreateModel(Rental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PartyId"] = new SelectList(_context.Parties, "Id", "Name");
        ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Name");
        ViewData["UnitTypeId"] = new SelectList(_context.UnitTypes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Unit Unit { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Units.Add(Unit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

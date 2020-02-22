using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rental.Data;
using Rental.Models;

namespace Rental.Pages.UnitPrices
{
    public class CreateModel : PageModel
    {
        private readonly Rental.Data.ApplicationDbContext _context;

        public CreateModel(Rental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int UnitId)
        {
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Code");
            UnitPrice = new UnitPrice();
            UnitPrice.UnitId = UnitId;
            return Page();        
        }

        [BindProperty]
        public UnitPrice UnitPrice { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UnitPrices.Add(UnitPrice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { UnitId = UnitPrice.UnitId });
        }
    }
}

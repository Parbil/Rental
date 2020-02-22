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
    public class IndexModel : PageModel
    {
        private readonly Rental.Data.ApplicationDbContext _context;

        public IndexModel(Rental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UnitPrice> UnitPrice { get;set; }

        public async Task OnGetAsync(int? UnitId)
        {
            if(UnitId == null)
            {
                UnitPrice = await _context.UnitPrices
                .Include(u => u.Unit).ToListAsync();
            }
            else
            {
                ViewData["UnitId"] = UnitId;
                UnitPrice = await _context.UnitPrices.Where(m => m.UnitId == UnitId)
                    .Include(u => u.Unit).ToListAsync();
            }
        }
    }
}

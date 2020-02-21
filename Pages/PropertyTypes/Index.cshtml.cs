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
    public class IndexModel : PageModel
    {
        private readonly Rental.Data.ApplicationDbContext _context;

        public IndexModel(Rental.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PropertyType> PropertyType { get;set; }

        public async Task OnGetAsync()
        {
            PropertyType = await _context.PropertyTypes.ToListAsync();
        }
    }
}

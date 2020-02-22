using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Rental.Data;
using Rental.Models;

namespace Rental.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        public List<PropertyType> PropertyTypes;
        public List<Property> Properties;
         
            public IndexModel (ApplicationDbContext dbcontext)
        {
            PropertyTypes = dbcontext.PropertyTypes.ToList();
            Properties= dbcontext.Properties.ToList();
        }
        public void OnGet()
        {

        }
    }
}

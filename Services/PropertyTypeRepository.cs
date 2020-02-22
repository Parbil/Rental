using Rental.Data;
using Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Services
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private ApplicationDbContext _dbcontext;
        public PropertyTypeRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public IEnumerable<PropertyType> GetPropertyTypes()
        {
           
            try
            {
                return _dbcontext.PropertyTypes.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}

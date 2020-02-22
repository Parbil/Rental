using Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Services
{
    public interface IPropertyTypeRepository
    {
        public IEnumerable<PropertyType> GetPropertyTypes();
    }
}

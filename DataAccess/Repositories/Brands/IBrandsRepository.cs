using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Brands
{
    public interface IBrandsRepository
    {
        Task<IEnumerable<Brand>> GetBrands();
    }
}

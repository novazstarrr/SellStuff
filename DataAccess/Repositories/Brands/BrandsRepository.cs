using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Brands
{
    internal class BrandsRepository : BaseRepository, IBrandsRepository 
    {
        public BrandsRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Brand?> GetBrandById(byte brandId)
        {
            return await Context.Brands.FirstOrDefaultAsync(brand => brand.Id == brandId);
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await Context.Brands
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

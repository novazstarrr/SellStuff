using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Brands
{
    internal class BrandsRepository : IBrandsRepository, BaseRepository
    {
        public BrandsRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await Context.Brands
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

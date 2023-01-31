using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.MemorySizes
{
    internal class MemorySizesRepository : BaseRepository, IMemorySizesRepository
    {
        public MemorySizesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MemorySize>> GetAll()

        {
          return await Context.MemorySizes
                .AsNoTracking()
                .OrderByDescending(x => x.Name)
                .ToListAsync();
                
        }

        public async Task<MemorySize?> GetMemorySizeById(byte memorySizeId)
        {
            return await Context.MemorySizes
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == memorySizeId);
        }
    }
}

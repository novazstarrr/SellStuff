using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.DeviceTypes
{
    internal class DeviceTypesRepository : BaseRepository, IDeviceTypesRepository 
    {
        public DeviceTypesRepository(ApplicationDbContext context) : base(context)
        {
        }

		public async Task<IEnumerable<DeviceType>> GetAll(short? brandId/*, string brandName*/)
		{
            var query = Context.DeviceTypes.AsNoTracking().Include(x => x.Brand).AsQueryable();
            
            if (brandId.HasValue)
            {
             query = query.Where(x => x.BrandId == brandId.Value);
            }

            return await query.OrderByDescending(x => x.Brand.Name).ToListAsync();
		}

		public async Task<DeviceType?> GetDeviceTypesById(byte deviceId)
		{
                 return await Context.DeviceTypes
                .AsNoTracking()
                .Include(x => x.Brand)
                .FirstOrDefaultAsync(DeviceId => DeviceId.Id == deviceId);
		}
		public async Task<DeviceType?> GetDeviceTypesByBrandId(byte brandId)
        {
            return await Context.DeviceTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(brandIdPrimary => brandIdPrimary.BrandId == brandId);
        }
	}
}

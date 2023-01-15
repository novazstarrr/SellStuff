using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.DeviceTypes
{
    internal class DeviceTypesRepository : IDeviceTypesRepository, BaseRepository
    {
        public DeviceTypesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DeviceType>> GetDeviceTypesByBrandId(byte brandId)
        {
            var deviceTypes = await Context.DeviceTypes
                .AsNoTracking()
                .Where(deviceType => deviceType.BrandId == brandId)
                .ToListAsync();
        }
    }
}

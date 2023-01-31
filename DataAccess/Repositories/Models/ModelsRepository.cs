using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Models
{
	internal class ModelsRepository : BaseRepository, IModelsRepository
	{
		public ModelsRepository(ApplicationDbContext context) : base(context)
		{
		}
		public async Task<IEnumerable<Model>> GetAll(byte? deviceTypeId)
		{
			var query = Context.Models.AsNoTracking();
			if (deviceTypeId.HasValue)
			{
				query.Where(x => x.DeviceTypeId == deviceTypeId.Value);
			}
			return await query.OrderByDescending(x => x.DeviceType).ToListAsync();
		}

		public async Task<Model?> GetModelById(short modelId)
		{
			return await Context.Models
				.AsNoTracking()
				.Include(x => x.DeviceType)
				.FirstOrDefaultAsync(i => i.Id == modelId);
		}

	}
}

using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.ModelsToMemorySizes
{
	internal class ModelsToMemorySizesRepository : BaseRepository, IModelsToMemorySizesRepostiory
	{
		public ModelsToMemorySizesRepository(ApplicationDbContext context) : base(context) 
		{
		}

		public async Task<IEnumerable<ModelToMemorySize>> GetAll(short? modelId)
		{
			var query = Context.ModelsToMemorySizes
				.AsNoTracking()
				.Include(x => x.Model)
				.Include(x => x.MemorySize)
				.AsQueryable();

			if (modelId.HasValue)
			{
				query = query.Where(x => x.ModelId == modelId.Value);
			}

			return await query

				.OrderByDescending(x => x.MemorySize.Name)
				.ToListAsync();
		}

		//public async Task<IEnumerable<ModelToMemorySize>> GetAllMemoryIdsFromModelIds(short modelId)
		//{
		//	return await Context.ModelsToMemorySizes
		//		.AsNoTracking()
		//		.Include(x => x.Model)
		//		.Include(x => x.MemorySize)
		//		.AsQueryable();
		//		.Where(i => i.ModelId == modelId)
		//		.OrderByDescending(i => i.Model.Name)
		//		.ToListAsync();
		//}
	}
}

using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.ViewModels.PricingMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.Repositories.PricingMatrixs
{
	internal class PricingMatrixRepository : BaseRepository, IPricingMatrixRepository
	{
		public PricingMatrixRepository(ApplicationDbContext context) : base(context)
		{

		}

		public async Task<IEnumerable<PricingMatrix>> GetAll(PricingMatrixQuery pricingMatrixQuery)
		{
			var query = Context.PricingMatrix
				.AsNoTracking()
				.Include(i => i.Model)
				.Include(i => i.MemorySize)
				.Include(i => i.Grade);

			if (pricingMatrixQuery.ModelId.HasValue)
			{
				query.Where(x => x.ModelId == pricingMatrixQuery.ModelId.Value);
			}

			if (pricingMatrixQuery.MemorySizeId.HasValue)
			{
				query.Where(x => x.MemorySizeId == pricingMatrixQuery.MemorySizeId.Value);
			}

			if (pricingMatrixQuery.GradeId.HasValue)
			{
				query.Where(x => x.GradeId == pricingMatrixQuery.GradeId.Value);
			}

			return await query
				.OrderByDescending(i => i.Model.Name)
				.ToListAsync();
		}


	}
}

using Models.Entities;
using Models.ViewModels.PricingMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.PricingMatrixs
{
	public interface IPricingMatrixRepository
	{
		Task<IEnumerable<PricingMatrix>> GetAll(PricingMatrixQuery query);

	}
}

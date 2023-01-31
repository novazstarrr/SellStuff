using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Models
{
	public interface IModelsRepository
	{
		Task<Model?>GetModelById(short modelId);

		Task<IEnumerable<Model>> GetAll(byte? deviceTypeId);

	}
}

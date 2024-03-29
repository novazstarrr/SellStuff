﻿using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.ModelsToMemorySizes
{
	public interface IModelsToMemorySizesRepostiory
	{
		Task<IEnumerable<ModelToMemorySize>> GetAll(short? modelId);

		}
}

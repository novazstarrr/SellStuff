using DataAccess.Repositories.Bookings;
using DataAccess.Repositories.Brands;
using DataAccess.Repositories.DeviceTypes;
using DataAccess.Repositories.Grades;
using DataAccess.Repositories.Grades.Grades;
using DataAccess.Repositories.MemorySizes;
using DataAccess.Repositories.Models;
using DataAccess.Repositories.ModelsToMemorySizes;
using DataAccess.Repositories.PricingMatrixs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utilities
{
	public static class ContainerSetup
	{
		public static void RegisterServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IBrandsRepository, BrandsRepository>();
			serviceCollection.AddTransient<IBookingsRepository, BookingsRepository>();
			serviceCollection.AddTransient<IDeviceTypesRepository, DeviceTypesRepository>();
			serviceCollection.AddTransient<IGradesRepository, GradesRepository>();
			serviceCollection.AddTransient<IMemorySizesRepository, MemorySizesRepository>();
			serviceCollection.AddTransient<IModelsRepository, ModelsRepository>();
			serviceCollection.AddTransient<IModelsToMemorySizesRepostiory, ModelsToMemorySizesRepository>();
			serviceCollection.AddTransient<IPricingMatrixRepository, PricingMatrixRepository>();

		}
	}
}

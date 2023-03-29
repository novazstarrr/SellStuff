using DataAccess.Repositories;
using DataAccess.Repositories.Bookings;
using DataAccess.Repositories.Brands;
using DataAccess.Repositories.DeviceTypes;
using DataAccess.Repositories.Grades;
using DataAccess.Repositories.Grades.Grades;
using DataAccess.Repositories.MemorySizes;
using DataAccess.Repositories.Models;
using DataAccess.Repositories.ModelsToMemorySizes;
using DataAccess.Repositories.PricingMatrixs;
using DataAccess.Repositories.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities;

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
			serviceCollection.AddTransient<IBookingTimesRepository, BookingTimesRepository>();
			serviceCollection.AddTransient<IUserRepository, UserRepository>();
		}
	}
}

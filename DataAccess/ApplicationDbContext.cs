
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;
using Models.Entities;

namespace DataAccess
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Brand> Brands { get; set; }

		public DbSet<DeviceType> DeviceTypes { get; set; }

		public DbSet<Model> Models { get; set; }

		public DbSet<MemorySize> MemorySizes { get; set; }

		public DbSet<ModelToMemorySize> ModelsToMemorySizes { get; set; }

		public DbSet<Grade> Grades { get; set; }

		public DbSet<PricingMatrix> PricingMatrix { get; set; }

		public DbSet<Booking> Bookings { get; set; }

		public DbSet<BookingTimeDefaults> BookingTimeDefaults { get; set; }

		public DbSet<BookingTimeHoliday> BookingTimeHolidays { get; set; }
	}
}
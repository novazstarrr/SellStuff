
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;

namespace DataAccess
{
	public class ApplicationDbContext :IdentityDbContext
	{
		public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
	}
}
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public DbInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex) 
            {
            
            }

            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Individual)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    FirstName = "Kenn",
                    LastName = "Millard",
                    AddressLine1 = "71",
                    AddressLine2 = "Northlands Road",
                    City = "Southampton",
                    PostCode = "SO515SA",
                    PhoneNumber = "07593792251",
                    UserName = "kennmillard@gmail.com",
                    Email = "kennmillard@gmail.com"
                }, "Admin_123*").GetAwaiter().GetResult();

                User user = _context.Userss.FirstOrDefault(u => u.Email == "kennmillard@gmail.com");

                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}

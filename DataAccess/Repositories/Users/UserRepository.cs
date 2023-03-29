using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Users
{
    internal class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User?> GetUserByUserId(string userId)
        {
            return await Context.Userss
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == userId);
         }

        public async Task<User> UpdateUser(User userPersonalInfo)
        {
            Context.Userss.Update(userPersonalInfo);

            await Context.SaveChangesAsync();

            return userPersonalInfo;
        }
    }
}

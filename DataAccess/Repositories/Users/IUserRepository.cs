using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUserId(string userId);

        Task<User> UpdateUser(User userPersonalInfo);
    }
}

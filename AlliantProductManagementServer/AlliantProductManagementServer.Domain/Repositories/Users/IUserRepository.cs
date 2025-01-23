using AlliantProductManagementServer.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Domain.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User?> GetUserByEmail(string email);
        Task<User?> LogIn(string email, string password);
    }
}

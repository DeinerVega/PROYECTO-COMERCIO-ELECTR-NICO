using E_COMMERCE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_COMMERCE.Repositories
{
    public interface IUserCollection
    {
        Task InsertUser(User user);

        Task UpdateUser(User user);

        Task DeleteUser(string id);

        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string id);
    }
}
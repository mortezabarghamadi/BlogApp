using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Domain.Entities;

namespace BlogApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> checkEmailisExist(string email);
        Task<User?> checkUserExistByEmailAndPassword(string email, string password);

        Task AddAsync(User user);
        Task SaveChangesAsync();

    }
}

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
        IQueryable<User> GetAllUsersAsQueryable();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> checkEmailisExist(string email);
        Task<User?> checkUserExistByEmailAndPassword(string email, string password);
        //افزودن کاربران 
        Task AddAsync(User user);
        //آپدیت اطلاعات
        void UpdateUser(User user);
        //حذف اکانت
        void DeleteUser(User user);
        Task SaveChangesAsync();

    }
}

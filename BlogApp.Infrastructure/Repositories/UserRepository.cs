using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Interfaces;
using BlogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogContext _context;
        public UserRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task<User?> checkUserExistByEmailAndPassword(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(p=>p.Email==email&&p.PasswordHash== password);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void UpdateUser(User user)
        {
             _context.Users.Update(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> checkEmailisExist(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public IQueryable<User> GetAllUsersAsQueryable()
        {
            return _context.Users.AsQueryable();
        }


        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
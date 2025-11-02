using BlogApp.Application.DTOs;
using BlogApp.Application.Services.Interfaces;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Services.Implementations
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        public async Task<UserDto> RegisterUserAsync(UserRegisterDto dto)
        {
            // بررسی تکراری نبودن ایمیل
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new Exception("کاربری با این ایمیل از قبل وجود دارد.");

            // ایجاد کاربر جدید
            var newUser = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = dto.Password // بعداً هش می‌کنیم
            };

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();

            return new UserDto
            {
                Id = newUser.Id,
                UserName = newUser.UserName,
                Email = newUser.Email
            };
        }
    }
}

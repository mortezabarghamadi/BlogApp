using BlogApp.Application.DTOs;
using BlogApp.Application.DTOs.AccountDto;
using BlogApp.Application.Services.Interfaces;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Security.Jwt.Interfaces;
using BlogApp.Application.Security.Passwordhelper.Interfaces;

namespace BlogApp.Application.Services.Implementations
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHelper _passwordHelper;

        public UserService(IUserRepository userRepository, IJwtService jwtService, IPasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _passwordHelper = passwordHelper;
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

        public async Task<UserRegisterDto.Registerresult> RegisterUserAsync(UserRegisterDto dto)
        {
            // بررسی تکراری نبودن ایمیل

            #region Validations

            var existingUser = await _userRepository.checkEmailisExist(dto.Email);
            if (existingUser)
                return UserRegisterDto.Registerresult.EmailIsExist;

            #endregion

            // ایجاد کاربر جدید
            var newUser = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = _passwordHelper.EncodePasswordMd5(dto.Password)
            };

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();

            return UserRegisterDto.Registerresult.Success;

        }

        public async Task<(UserLoginDto.LoginResult Result, string? Token)> LoginAsync(UserLoginDto dto)
        {
            var hashPassword = _passwordHelper.EncodePasswordMd5(dto.Password);

            var user = await _userRepository.checkUserExistByEmailAndPassword(dto.Email.ToLower().Trim(), hashPassword);
            if (user is null)
                return (UserLoginDto.LoginResult.Usernotfund, null);

            // ایجاد توکن JWT
            var token = _jwtService.GenerateToken(user);

            return (UserLoginDto.LoginResult.Success, token);
        }
    }
}

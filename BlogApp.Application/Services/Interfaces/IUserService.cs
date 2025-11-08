using BlogApp.Application.DTOs;
using BlogApp.Application.DTOs.AccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<UserRegisterDto.Registerresult> RegisterUserAsync(UserRegisterDto dto);
        Task<(UserLoginDto.LoginResult Result, string? Token)> LoginAsync(UserLoginDto dto);

    }
}

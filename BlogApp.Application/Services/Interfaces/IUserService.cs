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
        #region GetUser

        //گرفتن کاربران با آیدی آنها
        Task<UserDto?> GetUserByIdAsync(int id);


        #endregion


        #region Account

        //ثبت نام
        Task<UserRegisterDto.Registerresult> RegisterUserAsync(UserRegisterDto dto);
        //ورود
        Task<(UserLoginDto.LoginResult Result, string? Token)> LoginAsync(UserLoginDto dto);
        //ارسال ایمیل
        Task<bool> SendPasswordRecoveryEmailAsync(string email);
        //بازنشانی رمز عبور
        Task<bool> ResetPasswordAsync(string token, string newPassword);

        #endregion
    }
}

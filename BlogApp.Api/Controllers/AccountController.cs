using BlogApp.Application.DTOs.AccountDto;
using BlogApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
    public class AccountController : BaseSiteController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RegisterUserAsync(dto);

            return result switch
            {
                UserRegisterDto.Registerresult.Success => Ok(new { message = "ثبت‌نام با موفقیت انجام شد." }),
                UserRegisterDto.Registerresult.EmailIsExist => BadRequest(new { message = "ایمیل قبلاً ثبت شده است." }),
                _ => StatusCode(500, new { message = "خطا در ثبت‌نام کاربر." })
            };

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (result,token) = await _userService.LoginAsync(dto);

            return result switch
            {
                UserLoginDto.LoginResult.Success => Ok(new
                {
                    message = "ورود موفق بود.",
                    token = token
                }),
                UserLoginDto.LoginResult.Usernotfund => Unauthorized(new { message = "کاربری با این مشخصات یافت نشد."}),
                _ => StatusCode(500, new { message = "خطا در ورود کاربر." })
            };

        }
    }
}

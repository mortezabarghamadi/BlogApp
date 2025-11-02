using BlogApp.Application.DTOs;
using BlogApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
    public class AccountController : BaseSiteController
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            try
            {
                var result = await _userService.RegisterUserAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

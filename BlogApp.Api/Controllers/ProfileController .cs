using System.Security.Claims;
using BlogApp.Application.DTOs;
using BlogApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
    [Authorize]
    public class ProfileController : BaseSiteController
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var profile = await _profileService.GetProfileByUserIdAsync(userId);

            if (profile == null)
                return NotFound("پروفایل یافت نشد.");

            return Ok(profile);
        }


        [HttpPut("update")]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileDTO profileDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _profileService.UpdateProfileAsync(userId, profileDto);

            if (!result)
                return NotFound("پروفایل یافت نشد.");

            return Ok("پروفایل با موفقیت بروزرسانی شد.");
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProfile()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var result = await _profileService.DeleteProfileAsync(userId);

            if (!result)
                return BadRequest("عملیات حذف انجام نشد.");

            return Ok("پروفایل با موفقیت حذف شد.");
        }
    }
}
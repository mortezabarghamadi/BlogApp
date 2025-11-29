using System.Security.Claims;
using BlogApp.Application.DTOs;
using BlogApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
    [Authorize]
    public class PostController : BaseSiteController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetPostById(int id)
        {
            var post= await _postService.GetPostByidAsync(id);
            if (post==null)
            {
                return BadRequest("پست مورد نظر یافت نشد");
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

           
            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                await _postService.CreatPost(userId, dto);
                return Ok("پست با موفقیت ثبت شد");
            }

            return Unauthorized();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(PostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var uppost= await _postService.UpdatePost(userId, dto);
            if (uppost==false)
            {
                return BadRequest("اپدیت شکست خورد. پست یافت نشد");
            }
            return Ok("آپدیت با موفقیت انجام شد");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost()
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var delpost = await _postService.DeletePost(userid);
            if (delpost==false)
            {
                return BadRequest("حذف انجام نشد. پست پیدا نشد");
            }

            return Ok("پست با موفقیت پاک شد");
        }
    }
}

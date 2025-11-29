using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.DTOs;

namespace BlogApp.Application.Services.Interfaces
{
    public interface IPostService
    {
        Task<PostDto?> GetPostByidAsync(int userid);
        Task CreatPost(int userId, PostDto dto);
        Task<bool> UpdatePost(int userid, PostDto dto);
        Task<bool> DeletePost(int userid);
    }
}

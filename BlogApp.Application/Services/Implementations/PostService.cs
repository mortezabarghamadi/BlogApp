using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.DTOs;
using BlogApp.Application.Services.Interfaces;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Interfaces;

namespace BlogApp.Application.Services.Implementations
{
    public class PostService:IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<PostDto?> GetPostByidAsync(int userid)
        {
            var post = await _postRepository.GetByIdAsync(userid);
            if (post==null)
            {
                return null;
            }

            return new PostDto()
            {
                Title = post.Title,
                Content = post.Content
            };

        }
        
        public async Task CreatPost(int userId, PostDto dto)
        {
            var post = new Post()
            {
                AuthorId = userId,
                Title = dto.Title,
                Content = dto.Content,
                CreatedAt = DateTime.UtcNow
            };
            await _postRepository.AddAsync(post);
            await _postRepository.SaveChangesAsync();

        }

        public async Task<bool> UpdatePost(int userid ,PostDto dto)
        {
            var post = await _postRepository.GetByIdAsync(userid);
            if (post == null)
            {
                return false;
            }
            post.Title=dto.Title;
            post.Content=dto.Content;
            post.UpdateAt=DateTime.UtcNow;
            _postRepository.UpdateDelete(post);
            await _postRepository.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeletePost(int userid)
        {
            var post = await _postRepository.GetByIdAsync(userid);
            if (post==null)
            {
                return false;
            }

            _postRepository.DeletePost(post);
            await _postRepository.SaveChangesAsync();
            return true;
        }
    }
}

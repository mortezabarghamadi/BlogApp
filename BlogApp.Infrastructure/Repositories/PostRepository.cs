using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Interfaces;
using BlogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Infrastructure.Repositories
{
    public class PostRepository:IPostRepository
    {
        private readonly BlogContext _context;

        public PostRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task<Post?> GetByIdAsync(int postid)
        {
            return await _context.Posts.FindAsync(postid);
        }

        public async Task<IEnumerable<Post?>> GetAllAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
        }
        public void UpdateDelete(Post post)
        {
             _context.Posts.Update(post);
        }

        public void DeletePost(Post post)
        {
           _context.Posts.Remove(post);
        }

        

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

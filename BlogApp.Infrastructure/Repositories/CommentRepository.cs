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
    public class CommentRepository:ICommentRepository
    {
        private readonly BlogContext _context;
        public CommentRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetByPostIdAsync(int postId)
        {
            return await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
    }


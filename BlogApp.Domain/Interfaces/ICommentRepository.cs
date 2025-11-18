using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Domain.Entities;

namespace BlogApp.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment?> GetByIdAsync(int id);
        Task AddAsync(Comment comment);
        Task<IEnumerable<Comment>> GetByPostIdAsync(int postId);
        Task SaveChangesAsync();
    }
}

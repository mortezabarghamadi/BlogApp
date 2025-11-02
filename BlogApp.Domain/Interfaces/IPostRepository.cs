using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Domain.Entities;

namespace BlogApp.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<Post?> GetByIdAsync(int id);
        Task AddAsync(Post post);
        Task<IEnumerable<Post>> GetAllAsync();
        Task SaveChangesAsync();
    }
}

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
        #region Get

        Task<Post?> GetByIdAsync(int postid);
        Task<IEnumerable<Post?>> GetAllAsync();

        #endregion
        Task AddAsync(Post post);
        void DeletePost(Post post);
        void UpdateDelete(Post post);
        Task SaveChangesAsync();
    }
}

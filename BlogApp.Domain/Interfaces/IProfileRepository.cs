using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Domain.Entities;

namespace BlogApp.Domain.Interfaces
{
    public interface IProfileRepository
    {
        #region Get

        Task<Profile?> GetByUserIdAsync(int UserId);

        #endregion

        Task AddProfileAsync(Profile profile);
        void UpdateProfile(Profile profile);
        void DeleteProfile(Profile profile);
        Task SaveChangesAsync();
    }
}

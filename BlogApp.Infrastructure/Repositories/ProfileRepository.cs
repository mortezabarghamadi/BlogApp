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
    public class ProfileRepository:IProfileRepository
    {
        private readonly BlogContext _blogContext;

        public ProfileRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        #region Get

        public async Task<Profile?> GetByUserIdAsync(int UserId)
        {
            var profil= await _blogContext.Profiles.FirstOrDefaultAsync(p=>p.UserId==UserId);
            return profil;
        }

        #endregion

        public async Task AddProfileAsync(Profile profile)
        {
            await _blogContext.Profiles.AddAsync(profile);
        }

        public void UpdateProfile(Profile profile)
        {
            _blogContext.Profiles.Update(profile);
        }

        public void DeleteProfile(Profile profile)
        {
            _blogContext.Profiles.Remove(profile);
        }

        public async Task SaveChangesAsync()
        {
            await _blogContext.SaveChangesAsync();
        }
    }
}

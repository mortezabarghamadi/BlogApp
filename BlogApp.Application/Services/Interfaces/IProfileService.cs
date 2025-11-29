using BlogApp.Application.DTOs;
using BlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Application.Services.Interfaces
{
    public interface IProfileService
    {
        #region profile

        Task<ProfileDTO?> GetProfileByUserIdAsync(int userId);
        Task<UploadImageResultDto> UploadProfileImageAsync(int userId, IFormFile file);
        Task CreateProfileForNewUserAsync(int userId, string email);
        Task<bool> UpdateProfileAsync(int userId, ProfileDTO updated);
        Task<bool> DeleteProfileAsync(int userId);

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.DTOs;
using BlogApp.Application.Services.Interfaces;
using BlogApp.Domain.Entities;
using BlogApp.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Application.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _ProfileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _ProfileRepository = profileRepository;
        }

        public async Task<ProfileDTO?> GetProfileByUserIdAsync(int userId)
        {
            var profile = await _ProfileRepository.GetByUserIdAsync(userId);
            if (profile == null) return null;

            return new ProfileDTO()
            {
                DisplayName = profile.DisplayName,
                Bio = profile.Bio,
                Birthday = profile.Birthday,
                City = profile.City,
                Country = profile.Country,
                PersonalInterest = profile.PersonalInterest,
                PersonalWebsite = profile.PersonalWebsite,
                Phone = profile.Phone,
                ProfileImageUrl = profile.ProfileImageUrl,
                IsPublic = profile.IsPublic
            };
        }

        public async Task<UploadImageResultDto> UploadProfileImageAsync(int userId, IFormFile file)
        {
            // ۱) چک کردن پروفایل کاربر
            var profile = await _ProfileRepository.GetByUserIdAsync(userId);
            if (profile == null)
                return new(false, "پروفایل یافت نشد");

            // ۲) اعتبارسنجی فایل
            var allowedTypes = new[] { "image/png", "image/jpeg" };

            if (!allowedTypes.Contains(file.ContentType))
                return new(false, "فقط JPG یا PNG مجاز است");

            if (file.Length > 5 * 1024 * 1024)
                return new(false, "حداکثر حجم فایل ۵ مگابایت است");

            // ۳) ذخیره‌سازی فایل
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "profile-images");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var ext = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{ext}";
            var fullPath = Path.Combine(folder, fileName);

            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            // ۴) ساخت URL
            var fileUrl = $"/uploads/profile-images/{fileName}";

            // ۵) ذخیره در دیتابیس
            profile.ProfileImageUrl = fileUrl;
            profile.UpdatedAt = DateTime.UtcNow;

            _ProfileRepository.UpdateProfile(profile);
            await _ProfileRepository.SaveChangesAsync();

            return new(true, "تصویر با موفقیت آپلود شد", fileUrl);
        }



        public async Task CreateProfileForNewUserAsync(int userId, string email)
        {
            var exists = await _ProfileRepository.GetByUserIdAsync(userId);
            if (exists != null) return;

            var display = email?.Trim().Split('@')[0] ?? "user";

            var profile = new Profile()
            {
                UserId = userId,
                DisplayName = display,
                CreatedAt = DateTime.UtcNow,
                IsPublic = true
            };

            await _ProfileRepository.AddProfileAsync(profile);
            await _ProfileRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateProfileAsync(int userId, ProfileDTO updated)
        {
            var existing = await _ProfileRepository.GetByUserIdAsync(userId);
            if (existing == null) return false;

            existing.DisplayName = updated.DisplayName;
            existing.Bio = updated.Bio;
            existing.ProfileImageUrl = updated.ProfileImageUrl;
            existing.City = updated.City;
            existing.Country = updated.Country;
            existing.PersonalInterest = updated.PersonalInterest;
            existing.PersonalWebsite = updated.PersonalWebsite;
            existing.Phone = updated.Phone;
            existing.Birthday = updated.Birthday;
            existing.IsPublic = updated.IsPublic;
            existing.UpdatedAt = DateTime.UtcNow;

            _ProfileRepository.UpdateProfile(existing);
            await _ProfileRepository.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteProfileAsync(int userId)
        {
            var profile = await _ProfileRepository.GetByUserIdAsync(userId);
            if (profile == null) return false;

            _ProfileRepository.DeleteProfile(profile);
            await _ProfileRepository.SaveChangesAsync();

            return true;
        }
    }

}

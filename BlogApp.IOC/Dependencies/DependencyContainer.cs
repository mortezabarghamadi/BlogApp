using BlogApp.Application.Security.Jwt.Implementations;
using BlogApp.Application.Security.Jwt.Interfaces;
using BlogApp.Application.Services.Implementations;
using BlogApp.Application.Services.Interfaces;
using BlogApp.Domain.Interfaces;
using BlogApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Security.Passwordhelper.Implementations;
using BlogApp.Application.Security.Passwordhelper.Interfaces;

namespace BlogApp.IOC.Dependencies
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            #region Service

            service.AddScoped<IProfileService, ProfileService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IJwtService, JwtService>();
            service.AddScoped<IPasswordHelper, PasswordHelper>();

            #endregion

            #region Repository

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IPostRepository, PostRepository>();
            service.AddScoped<ICommentRepository, CommentRepository>();
            service.AddScoped<IProfileRepository, ProfileRepository>();

            #endregion
        }
    }
}

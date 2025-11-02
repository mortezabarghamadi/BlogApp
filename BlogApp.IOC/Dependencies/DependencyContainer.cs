using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Services.Implementations;
using BlogApp.Application.Services.Interfaces;
using BlogApp.Domain.Interfaces;
using BlogApp.Infrastructure.Repositories;

namespace BlogApp.IOC.Dependencies
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            #region Service

            service.AddScoped<IUserService, UserService>();
            #endregion

            #region Repository

            service.AddScoped<IUserRepository,UserRepository>();
            service.AddScoped<IPostRepository,PostRepository>();
            service.AddScoped<ICommentRepository,CommentRepository>();

            #endregion
        }
    }
}

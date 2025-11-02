using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Domain.Interfaces;
using BlogApp.Infrastructure.Repositories;

namespace BlogApp.IOC.Dependencies
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            #region Service

            #endregion

            #region Repository

            service.AddScoped<IUserRepository,UserRepository>();
            service.AddScoped<IPostRepository,PostRepository>();
            service.AddScoped<ICommentRepository,CommentRepository>();

            #endregion
        }
    }
}

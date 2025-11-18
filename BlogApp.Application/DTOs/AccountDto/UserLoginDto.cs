using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DTOs.AccountDto
{
    public class UserLoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public enum LoginResult
        {
            Success,
            Error,
            UserNotFound,
            EmailIsNotActive
        }
    }

}

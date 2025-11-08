using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DTOs.AccountDto
{
    public class UserRegisterDto
    {
        public string UserName { get; set; } = string.Empty;    
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public enum Registerresult
        {
            Success,
            Error,
            EmailIsExist
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Entities
{
    public class User
    {
        #region property
        public int Id { get; set; }
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; } = string.Empty;
        [Display(Name = "ایمیل")]
        public string Email { get; set; } = string.Empty;
        [Display(Name = "پسورد هش شده")]
        public string PasswordHash { get; set; } = string.Empty;
        [Display(Name = "زمان ایحاد اکانت")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //متد بازگشایی رمز عبور 
        [Display(Name = "توکن بازنشانی رمز عبور")]
        public string? PasswordRecoveryCode { get; set; }

        [Display(Name = "زمان انقضای توکن بازنشانی")]
        public DateTime PasswordRecoveryCodeExpireDate { get; set; }
        #endregion

        #region Navigation
        public Profile Profile { get; set; }   // 1-1
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        #endregion
    }
}

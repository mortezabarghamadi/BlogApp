using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Entities
{
    public class User
    {
        #region property
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        #endregion

        #region Navigation
        public Profile Profile { get; set; }   // 1-1
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        #endregion
    }
}

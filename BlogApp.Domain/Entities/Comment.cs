using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Entities
{
    public class Comment
    {
        #region Property
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        #endregion
        #region Foreign Keys
        public int PostId { get; set; }
        public int UserId { get; set; }
        #endregion
        #region Navigation
        public Post Post { get; set; }
        public User User { get; set; }
        #endregion
    }
}

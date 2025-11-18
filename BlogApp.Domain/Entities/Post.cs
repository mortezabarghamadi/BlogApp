using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Entities
{
    public class Post
    {
        #region Property

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        #endregion

        #region Foreign Keys
        public int AuthorId { get; set; }
        #endregion

        #region Navigation
        public User Author { get; set; }
        public ICollection<Comment> Comments { get; set; }

        #endregion

    }
}

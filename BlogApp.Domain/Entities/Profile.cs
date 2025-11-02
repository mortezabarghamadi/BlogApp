using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Entities
{
    public class Profile
    {
        #region Property

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Bio { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;

        #endregion

        #region Navigation
        public User User { get; set; }
        #endregion

    }
}

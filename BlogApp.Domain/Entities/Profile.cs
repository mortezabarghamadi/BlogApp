using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Entities
{
    public class Profile
    {
        public int Id { get; set; }

        // Foreign key
        public int UserId { get; set; }

        #region Properties

        public string? DisplayName { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PersonalInterest { get; set; }
        public string? PersonalWebsite { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthday { get; set; }

        #endregion

        public bool IsPublic { get; set; } = true;

        // Audit fields
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        #region Navigation
        public User? User { get; set; }
        #endregion
    }

}

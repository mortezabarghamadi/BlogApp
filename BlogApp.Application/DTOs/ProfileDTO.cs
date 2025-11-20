using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DTOs
{
    public class ProfileDTO
    {
        public string? DisplayName { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PersonalInterest { get; set; }
        public string? PersonalWebsite { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public bool IsPublic { get; set; } = true;

    }
}

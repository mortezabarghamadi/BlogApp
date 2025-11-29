using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DTOs
{
    public class UploadImageResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string? ImageUrl { get; set; }

        public UploadImageResultDto(bool success, string message, string? imageUrl = null)
        {
            Success = success;
            Message = message;
            ImageUrl = imageUrl;
        }

    }
}

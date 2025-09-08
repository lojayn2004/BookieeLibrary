

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Books.Admin
{
    public class AddBookDto
    {
        [Required]

        public string ISBN { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        [Required]
        public string Edition { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string? PictureUrl { get; set; } = string.Empty;

        public IFormFile BookPicture { get; set; }

        public int CategoryId { get; set; }

     
        public int AvaliableQuantity { get; set; }

    }
}

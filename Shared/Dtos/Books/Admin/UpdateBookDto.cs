using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Books.Admin
{
    public class UpdateBookDto
    {
        [Required]
        public string ISBN { get; set; } = string.Empty;

       
        public string? Title { get; set; }

        
        public string? Author { get; set; }

       
        public string? Edition { get; set; }


        public string? Description { get; set; }

        public int? CategoryId { get; set; }

    

        public int? AvaliableQuantity { get; set; }
    }
}

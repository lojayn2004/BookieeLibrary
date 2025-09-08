using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Books.Admin
{
    public class AdminBookDto
    {
        
        public string ISBN { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

       
        public string Author { get; set; } = string.Empty;

        
        public string Edition { get; set; } = string.Empty;

        
        public string Description { get; set; } = string.Empty;

        public int CategoryId { get; set; } 

       
        public string CategoryName { get; set; } = string.Empty;

        public int AvaliableQuantity { get; set; }

        
        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }
    }
}

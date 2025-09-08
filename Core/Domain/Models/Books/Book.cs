using Domain.Models.Users;

namespace Domain.Models.Books
{
    public class Book
    {
        public string ISBN { get; set; } = string.Empty;  
   
    
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Edition { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;

        public string PictureUrl {  get; set; } = string.Empty; 

        public int BorrowedQuantity { get; set; } 
        public int AvaliableQuantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<BorrowBookDetails> Students { get; set; } = new HashSet<BorrowBookDetails>();



    }
}

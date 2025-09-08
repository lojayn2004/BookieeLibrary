using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Books.Student
{
    public class BookDto
    {
        

        public string ISBN { get; set; } = string.Empty;

        
        public string Title { get; set; } = string.Empty;

        
        public string Author { get; set; } = string.Empty;

       
        public string Edition { get; set; } = string.Empty;

        
        public string Description { get; set; } = string.Empty;


        public string CategoryName { get; set; } = string.Empty;

        public int CategoryId { get; set; } 

        public int AvaliableQuantity { get; set; }

       

    }
}


namespace Domain.Models.Books
{
    public class Category
    {
        public int Id { get; set; } 

        public string CategoryName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;


        public string CategoryClassIcon { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    
    }
}

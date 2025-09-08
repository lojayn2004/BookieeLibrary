using Domain.Models.Users;

namespace Domain.Models.Books
{
    public class BorrowBookDetails
    {
        public int Id { get; set; } 
        public string StudentId { get; set; }  = string.Empty;

        public string BookId { get; set; }  = string.Empty;

        public DateTime BorrowDate { get; set; }    

        public DateTime ReturnDate {  get; set; }

        public bool IsReturned { get; set; }


        public Book Book { get; set; }

        public Student Student { get; set; }    

 
    }
}

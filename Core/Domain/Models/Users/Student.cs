

namespace Domain.Models.Users
{
    public class Student: User
    {
        public string UniverstyId { get; set; } = string.Empty;
        public bool IsVerified { get; set; }


        public ICollection<BorrowBookDetails> BorrowedBooks { get; set; } = new HashSet<BorrowBookDetails>();


    }
}

using Shared.Dtos.Books.Student;


namespace ServicesAbstraction.BookServices
{
    public interface IBorrowService
    {
        Task BorrowBook(BorrowBookDto borrowBookDto);

        Task ReturnBook(ReturnBookDto returnBookDto);
    }
}

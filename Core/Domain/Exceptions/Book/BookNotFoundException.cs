
namespace Domain.Exceptions.Book
{
    public class BookNotFoundException: NotFoundException
    {
        public BookNotFoundException(string isbn): base($"Book with isbn {isbn} is not found") { }
    }
}




namespace Domain.Exceptions.Book
{
    public class BookNotBorrowedException : Exception
    {
        public BookNotBorrowedException(string bookId, string studentId):
            base($"Book with ID {bookId} is not currently borrowed by student {studentId}")
        {
        }
    }
}

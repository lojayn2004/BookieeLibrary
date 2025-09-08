using Shared.Dtos.Books.Student;

namespace Services.BookServices
{
    public class BorrowService(IUnitOfWork _unitOfWork) : IBorrowService
    {
        private readonly IGenericRepository<Book, string>  _bookRepository = _unitOfWork.GetRepository<Book, string>();

        private readonly IGenericRepository<BorrowBookDetails, BorrowBookKey> _borrowBookRepository = _unitOfWork.GetRepository<BorrowBookDetails, BorrowBookKey>();

        public async Task BorrowBook(BorrowBookDto borrowBookDto)
        {
            

            await VerifyAndUpdateBookQuantity(borrowBookDto.BookIsbn);

            var student = await GetStudent(borrowBookDto.StudentUniverstyId);

            BorrowBookDetails borrowBook = new BorrowBookDetails()
            {
                StudentId = student.Id,
                BookId = borrowBookDto.BookIsbn,
                BorrowDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7)
            };


            _borrowBookRepository.Add(borrowBook);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task ReturnBook(ReturnBookDto returnBookDto)
        {
            var student = await GetStudent(returnBookDto.StudentUniverstyId);

            var borrowBookKey = new BorrowBookKey(student.Id, returnBookDto.BookIsbn);
            var borrowingDetails =  await _borrowBookRepository.GetByIdAsync(new BorrowBookSpecification(borrowBookKey));

            if (borrowingDetails == null)
                throw new BookNotBorrowedException(returnBookDto.BookIsbn, returnBookDto.StudentUniverstyId);
           
            borrowingDetails.IsReturned = true;
            borrowingDetails.Book.AvaliableQuantity++;
            _bookRepository.Update(borrowingDetails.Book);


            await _unitOfWork.SaveChangesAsync();
        }

        private async Task VerifyAndUpdateBookQuantity(string bookIsbn)
        {
            var book = await _bookRepository.GetByIdAsync(bookIsbn);
            if (book == null)
                throw new BookNotFoundException(bookIsbn);
            if (book.AvaliableQuantity == 0)
                throw new InSufficientBookQuantity(bookIsbn);

            book.AvaliableQuantity--;
            _bookRepository.Update(book);

        }

        private async Task<Student> GetStudent(string studentUniverstyId)
        {

            var studentRepos = _unitOfWork.GetRepository<Student, string>();
            var student = await studentRepos.GetByIdAsync(new StudentWithUniverstyIdSpecification(studentUniverstyId)) as Student;

            if (student == null || student.IsVerified == false)
                throw new UserNotFoundException($"Student with Id {studentUniverstyId} is not found or unverified");

            return student;
        
        }

       
    }
}

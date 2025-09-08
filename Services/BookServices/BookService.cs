using Shared.Dtos.Books.Student;
using Shared.Specifications;

namespace Services.BookServices
{
    public class BookService(IUnitOfWork _unitOfWork, IMapper _mapper) : IBookService
    {

        public async Task<PaginatedResponse<BookDto>> GetAllAsync(BookParametersSpecifications bookParameters)
        {
            var repo = _unitOfWork.GetRepository<Book, string>();
            var allBooks = await repo.GetAllAsync(new BookWithCategorySpecification(bookParameters));
            var totalBooks = await repo.GetAllAsync(new BookCountSpecification(bookParameters));
            var returnedBooks =  _mapper.Map<IEnumerable<BookDto>>(allBooks);
            return new PaginatedResponse<BookDto>()
            {
                PageIndex = bookParameters.PageIndex,
                PageSize = bookParameters.PageSize,
                TotalCount = totalBooks.Count(),
                Data = returnedBooks
            };
        }

        public async Task<BookDto> GetByIdAsync(string isbn)
        {
            var repo = _unitOfWork.GetRepository<Book, string>();
            var book = await repo.GetByIdAsync(new BookWithCategorySpecification(isbn));

            return _mapper.Map<BookDto>(book);
        }
    }
}

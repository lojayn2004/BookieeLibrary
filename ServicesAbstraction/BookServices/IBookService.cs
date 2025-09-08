using Shared.Dtos.Books;
using Shared.Dtos.Books.Student;
using Shared.Specifications;

namespace ServicesAbstraction.BookServices
{
    public interface IBookService
    {
        public Task<PaginatedResponse<BookDto>> GetAllAsync(BookParametersSpecifications bookParameters);

        public Task<BookDto> GetByIdAsync(string isbn);


    }
}

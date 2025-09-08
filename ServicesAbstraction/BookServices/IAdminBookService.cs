using Shared.Dtos.Books;
using Shared.Dtos.Books.Admin;
using Shared.Specifications;

namespace ServicesAbstraction.BookServices
{
    public interface IAdminBookService
    {
        public Task<PaginatedResponse<AdminBookDto>> GetAllAsync(BookParametersSpecifications bookParameters);

        public Task<AdminBookDto> GetByIdAsync(string isbn);

        public Task AddAsync(AddBookDto bookDto);

        public Task UpdateAsync(UpdateBookDto bookDto);

        public Task DeleteAsync(string isbn);
    }
}



using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Exceptions.Book;
using Domain.Models.Books;
using Services.Specifications;
using ServicesAbstraction.BookServices;
using ServicesAbstraction.GeneralServices;
using Shared.Dtos.Books.Admin;
using Shared.Specifications;

namespace Services.BookServices
{
    public class AdminBookService(IUnitOfWork _unitOfWork, IMapper _mapper, IAttatchementService _attatchementService) : IAdminBookService
    {

       
        public async Task<PaginatedResponse<AdminBookDto>> GetAllAsync(BookParametersSpecifications bookParameters)
        {
            var repo = _unitOfWork.GetRepository<Book, string>();
            var allBooks = await repo.GetAllAsync(new BookWithCategorySpecification(bookParameters));
            var totalBooks = await repo.GetAllAsync(new BookCountSpecification(bookParameters));

            var returnedBooks = _mapper.Map<IEnumerable<AdminBookDto>>(allBooks);
            return new PaginatedResponse<AdminBookDto>()
            {
                PageSize = bookParameters.PageSize,
                PageIndex =  bookParameters.PageIndex,
                TotalCount = totalBooks.Count(),
                Data  = returnedBooks
            };
         
        }

        public async Task<AdminBookDto> GetByIdAsync(string isbn)
        {
            var repo = _unitOfWork.GetRepository<Book, string>();
            var book = await repo.GetByIdAsync(new BookWithCategorySpecification(isbn));

            if(book == null) 
                throw new BookNotFoundException(isbn);
            return _mapper.Map<AdminBookDto>(book);
        }

        public async Task AddAsync(AddBookDto bookDto)
        {
            var repo = _unitOfWork.GetRepository<Book, string>();
             string fileName = _attatchementService.Upload(bookDto.BookPicture, "books");
             bookDto.PictureUrl = fileName;
             var book = _mapper.Map<Book>(bookDto);

            if (book == null)
                throw new ArgumentNullException(nameof(bookDto));
            
            repo.Add(book);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateBookDto bookDto)
        {
            if (bookDto == null)
                throw new ArgumentNullException(nameof(bookDto));

            var repo = _unitOfWork.GetRepository<Book, string>();
            var existingBook = await repo.GetByIdAsync(bookDto.ISBN);
            if (existingBook == null)
                throw new BookNotFoundException(bookDto.ISBN);

            existingBook.Author = bookDto.Author ?? existingBook.Author;
            existingBook.Description = bookDto.Description ?? existingBook.Description;
            existingBook.Title = bookDto.Title ?? existingBook.Title;
            existingBook.Edition = bookDto.Edition ?? existingBook.Edition;
            existingBook.CategoryId = bookDto.CategoryId ?? existingBook.CategoryId;
            existingBook.AvaliableQuantity = bookDto.AvaliableQuantity ?? existingBook.AvaliableQuantity;


            repo.Update(existingBook);
            await _unitOfWork.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(string isbn)
        {
            var repo = _unitOfWork.GetRepository<Book, string>();
          
            var bookToBeDeleted = await repo.GetByIdAsync(isbn);

            if (bookToBeDeleted == null)
                throw new BookNotFoundException(isbn);

            if (bookToBeDeleted.BorrowedQuantity > 0)
                throw new Exception($"Book with isbn {isbn} cannot be deleted bec it is borrowed by student");

          

            _attatchementService.Delete(bookToBeDeleted.PictureUrl);
            repo.Delete(bookToBeDeleted);

            await _unitOfWork.SaveChangesAsync();


        }


    }
}

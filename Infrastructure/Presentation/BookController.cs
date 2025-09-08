
using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction.GeneralServices;
using Shared.Dtos.Books.Student;
using Shared.Specifications;

namespace Presentation
{
    [ApiController]
    [Route("api/books")]
    public class BookController(IServiceManager _serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll([FromQuery] BookParametersSpecifications bookParameters)
        {

            var books = await _serviceManager.BookService.GetAllAsync(bookParameters);
            return Ok(books);

        }

        [HttpGet("{isbn}")]
        public async Task<ActionResult<BookDto>> GetBookById(string isbn)
        {
            var book = await _serviceManager.BookService.GetByIdAsync(isbn);
            return Ok(book);
        }

    }
}

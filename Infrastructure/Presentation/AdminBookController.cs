

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction.GeneralServices;
using Shared.Dtos.Books.Admin;
using Shared.Specifications;

namespace Presentation
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/admin/[Controller]")]
    public class AdminBookController(IServiceManager _serviceManager): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminBookDto>>> GetAll([FromQuery] BookParametersSpecifications bookParameters)
        {

            var books = await _serviceManager.AdminBookService.GetAllAsync(bookParameters);
            return Ok(books);

        }

        [HttpGet("{isbn}")]
        public async Task<ActionResult<AdminBookDto>> GetBookById(string isbn)
        {
            var book = await _serviceManager.AdminBookService.GetByIdAsync(isbn);
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> AddBook(AddBookDto book)
        {
            await _serviceManager.AdminBookService.AddAsync(book);
            return Ok(book);

        }

        [HttpPatch]
        public async Task<ActionResult> UpdateBook(UpdateBookDto book)
        {
            await _serviceManager.AdminBookService.UpdateAsync(book);
            return Ok();

        }


        [HttpDelete("{isbn}")]
        public async Task<ActionResult> DeleteBook(string isbn)
        {
            await _serviceManager.AdminBookService.DeleteAsync(isbn);
            return Ok();
        }

    }
}

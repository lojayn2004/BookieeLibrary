
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction.GeneralServices;
using Shared.Dtos.Books.Student;

namespace Presentation
{
    //[Authorize(Roles = "Student")]
    [ApiController]
    [Route("api/borrow")]
    public class BorrowController(IServiceManager _serviceManager): ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> BorrowBook(BorrowBookDto borrowBookDto)
        {
            await _serviceManager.BorrowService.BorrowBook(borrowBookDto);
            return Ok();
        }

        [HttpPost]
        [Route("return")]
        public async Task<ActionResult<string>> ReturnBook(ReturnBookDto returnBookDto)
        {
            await _serviceManager.BorrowService.ReturnBook(returnBookDto);
            return Ok("Book is returned successfully");


        }
    }
}

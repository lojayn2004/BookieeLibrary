

using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction.GeneralServices;
using Shared.Dtos.Authorization;
using Shared.Dtos.Users;

namespace Presentation
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController(IServiceManager _serviceManager): ControllerBase
    {


        [HttpPost]
        [Route(("register/admin"))]
        public async Task<ActionResult<string>> Register(AdminRegisterDto adminRegisterDto)
        {
            await _serviceManager.UserService.RegisterAdmin(adminRegisterDto);
            return Ok($"Admin {adminRegisterDto.UserName} is created successfully");

        }

        [HttpPost]
        [Route("register/student")]
        public async Task<ActionResult<string>> Register(StudentRegisterDto studentRegisterDto)
        {
            await _serviceManager.UserService.RegisterStudent(studentRegisterDto);
            return Ok($"Student {studentRegisterDto.UserName} is created successfully");
        }

        [HttpPost]
        [Route("login")] 
        public async Task<ActionResult<UserResultDto>> Login(LoginDto loginDto)
        {
            return Ok(await _serviceManager.UserService.Login(loginDto));
        }


        //[Authorize(Roles = "Admin")]
        [HttpPatch("verify/{studentEmail}")]
        public async Task<ActionResult<string>> VerifyStudent(string studentEmail)
        {
            await _serviceManager.UserService.VerifyStudent(studentEmail);
            return Ok($"Student with email {studentEmail} is verified successfully");
        }
    }
}

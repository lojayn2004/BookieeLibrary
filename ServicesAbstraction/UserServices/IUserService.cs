using Shared.Dtos.Authorization;
using Shared.Dtos.Users;

namespace ServicesAbstraction.UserServices
{
    public interface IUserService
    {
        public Task<UserResultDto> Login(LoginDto loginDto);
        public Task RegisterAdmin(AdminRegisterDto adminRegisterDto);

        public Task RegisterStudent(StudentRegisterDto studentRegisterDto);

        public Task VerifyStudent(string studentUniverstyId);
    }
}




using Shared.Dtos.Authorization;
using Shared.Dtos.Users;

namespace Services.UserServices
{
    public class UserService(UserManager<User> _userManager, IOptions<JwtOption> _options) : IUserService
    {
        

        // need to change this so it may read from configuration or see what is the best practice 
        private readonly string SignUpAdminSecurityKey = "kdskdlakldkalkd2902964vg34h3g26t31cvvcLKKL";
        
        public async Task RegisterAdmin(AdminRegisterDto adminRegisterDto)
        {
            if (!ValidAdminSignUpKey(adminRegisterDto.RegisterSecurityKey))
                throw new UnAuthorizedException("Admin Unauthorized to sign up");

            var admin = new Admin()
            {
                UserName = adminRegisterDto.UserName,
                Email = adminRegisterDto.Email,
                PhoneNumber = adminRegisterDto.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(admin, adminRegisterDto.Password);
            
           
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                // must handle this 
                throw new Exception();
            }

            await _userManager.AddToRoleAsync(admin, "Admin");
        }

        public async Task RegisterStudent(StudentRegisterDto studentRegisterDto)
        {
            var student = new Student()
            {
                UserName = studentRegisterDto.UserName,
                Email = studentRegisterDto.Email,
                PhoneNumber = studentRegisterDto.PhoneNumber,
                UniverstyId = studentRegisterDto.UniverstyId

            };
            var result = await _userManager.CreateAsync(student, studentRegisterDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                // must handle this 
                throw new Exception();
            }

            await _userManager.AddToRoleAsync(student, "Student");
        }

       

        public async Task VerifyStudent(string studentEmail)
        {
            Student student = await _userManager.FindByEmailAsync(studentEmail) as Student 
                ?? throw new UserNotFoundException($"Invalid Student Email {studentEmail}");

            student.IsVerified = true;
            await _userManager.UpdateAsync(student);
        }


      

        public async Task<UserResultDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result)
                throw new Exception();

            return new UserResultDto()
            {
                Email = loginDto.Email,
                Token = await CreateTokenAsync(user)
            };

        }

        private async Task<string> CreateTokenAsync(User user)
        {
            var jwtOptions = _options.Value;
            var claims = new List<Claim>();
            claims.Add(new(ClaimTypes.Name, user.UserName!));
            claims.Add(new(ClaimTypes.Email, user.Email!));

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
                claims.Add(new(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));
            var singingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

          

            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issuer ,
                audience: jwtOptions.Audience, 
                claims: claims,
                expires: DateTime.UtcNow.AddDays(jwtOptions.ExpirationsDays),
                signingCredentials: singingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private bool ValidAdminSignUpKey(string signUpKey)
        {

            return SignUpAdminSecurityKey == signUpKey;
        }
    }
}

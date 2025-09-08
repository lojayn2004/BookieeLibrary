using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Users
{
    public class AdminRegisterDto
    {
        [Required]
        
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string RegisterSecurityKey { get; set; } = string.Empty;


    }
}

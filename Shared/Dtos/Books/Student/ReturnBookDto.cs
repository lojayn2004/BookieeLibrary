using System.ComponentModel.DataAnnotations;


namespace Shared.Dtos.Books.Student
{
    public class ReturnBookDto
    {
        [Required]
        public string BookIsbn { get; set; } = string.Empty;

        [Required]
        public string StudentUniverstyId { get; set; } = string.Empty;
    }
}

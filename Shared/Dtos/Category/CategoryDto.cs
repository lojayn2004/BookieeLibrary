using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }


        [Required]
        public string CategoryName { get; set; } = string.Empty;


        [Required]

        [RegularExpression(@"^(fas|far|fal|fab|fad|fat) fa-[a-z0-9-]+$")]
        public string CategoryClassIcon { get; set; } = string.Empty;


        [Required]
        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;

    }
}

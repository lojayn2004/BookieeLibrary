using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Category
{
    public class UpdateCategoryDto
    {
        [Required]
        public int Id { get; set; }

        public string? CategoryName { get; set; }

        [RegularExpression(@"^(fas|far|fal|fab|fad|fat) fa-[a-z0-9-]+$")]
        public string? CategoryClassIcon { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }
    }
}

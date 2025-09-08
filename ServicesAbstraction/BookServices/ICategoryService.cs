using Shared.Dtos.Category;

namespace ServicesAbstraction.BookServices
{
    public interface ICategoryService
    {
        
        Task AddCategoryAsync(CategoryDto categoryDto);

      
        Task UpdateCategoryAsync(UpdateCategoryDto categoryDto);

        
        Task DeleteCategoryAsync(int categoryId);

        
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();

      
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
    }
}

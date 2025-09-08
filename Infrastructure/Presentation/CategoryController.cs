

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction.GeneralServices;
using Shared.Dtos.Category;

namespace Presentation
{
   
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController(IServiceManager _manager) : ControllerBase
    {
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var categories = await _manager.CategoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{CategoryId}")]
        public async Task<ActionResult<CategoryDto>> GetById(int CategoryId)
        {
            var categories = await _manager.CategoryService.GetCategoryByIdAsync(CategoryId);
            return Ok(categories);
        }

       // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> AddCategory(CategoryDto categoryDto)
        {
            await _manager.CategoryService.AddCategoryAsync(categoryDto);
            return Ok(categoryDto);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            await _manager.CategoryService.UpdateCategoryAsync(categoryDto);
            return Ok(categoryDto);
        }
        
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{CategoryId}")]
        public async Task<ActionResult> DeleteCategory(int categoryId)
        {
            await _manager.CategoryService.DeleteCategoryAsync(categoryId);
            return Ok($"Category with id {categoryId} is deleted successfully");
        }


    }
}

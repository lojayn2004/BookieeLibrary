


namespace Services.BookServices
{
    public class CategoryService(IUnitOfWork _unitOfWork, IMapper _mapper) : ICategoryService
    {
        // must check if their is repeated category name 
        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var repo = _unitOfWork.GetRepository<Category, int>();
            var  category = _mapper.Map<Category>(categoryDto);

            repo.Add(category);

            await _unitOfWork.SaveChangesAsync();
            
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var repo = _unitOfWork.GetRepository<Category, int>();
            var category = await repo.GetByIdAsync(categoryId);
            if(category == null)
                throw new CategoryNotFoundException(categoryId);    
            repo.Delete(category);

            await _unitOfWork.SaveChangesAsync();   

        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            var categoryRepo = _unitOfWork.GetRepository<Category, int>();
            var category = await categoryRepo.GetByIdAsync(categoryDto.Id);

            if (category == null)
            
                throw new CategoryNotFoundException(categoryDto.Id);
         
            category.Description = categoryDto.Description ?? category.Description;
            category.CategoryName = categoryDto.CategoryName ?? category.CategoryName;
            category.CategoryClassIcon = categoryDto.CategoryClassIcon ?? category.CategoryClassIcon;


            categoryRepo.Update(category);

            await  _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var repo = _unitOfWork.GetRepository<Category, int>();
            var allCategories = await repo.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(allCategories);

        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var repo = _unitOfWork.GetRepository<Category, int>();
            var category = await repo.GetByIdAsync(categoryId);
           
            if (category == null)
                throw new CategoryNotFoundException(categoryId);

            return _mapper.Map<CategoryDto>(category); 
        }

       
    }
}

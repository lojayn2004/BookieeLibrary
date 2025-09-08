
namespace Domain.Exceptions.Category
{
    public class CategoryNotFoundException: NotFoundException
    {
        public CategoryNotFoundException(int categoryId)
            : base($"Category with id ${categoryId} is not found")
        { 
        
        }

    }
}

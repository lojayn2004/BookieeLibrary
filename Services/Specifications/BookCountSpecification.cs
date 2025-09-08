



using Shared.Specifications;

namespace Services.Specifications
{
    public class BookCountSpecification: Specification<Book>
    {
        public BookCountSpecification(BookParametersSpecifications booksParams) :
           base(GetCriteria(booksParams))
        {
          
        }

        private static Expression<Func<Book, bool>> GetCriteria(BookParametersSpecifications booksParams)
        {
            return (b) =>
            (booksParams.CategoryId == null || b.CategoryId == booksParams.CategoryId) &&
            (string.IsNullOrWhiteSpace(booksParams.SearchByTitle) || b.Title == booksParams.SearchByTitle);
        }

    }
    

    
}

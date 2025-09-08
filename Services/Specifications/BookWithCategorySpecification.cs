


using Shared.Specifications;

namespace Services.Specifications
{
    public class BookWithCategorySpecification : Specification<Book>
    {
        public BookWithCategorySpecification(string isbn) :
            base((b) => b.ISBN == isbn)
        {
            AddInclude(b => b.Category);
        }

        public BookWithCategorySpecification(BookParametersSpecifications booksParams) :
            base(GetCriteria(booksParams))
        {
            AddInclude(b => b.Category);

            if(booksParams.BookSort is not null)
            {
                switch (booksParams.BookSort)
                {
                    case BookSort.BookISBNAsc:
                        AddOrderBy(b => b.ISBN);
                        break;
                    case BookSort.BookISBNDesc:
                        AddOrderByDesc(b => b.ISBN);
                        break;
                    case BookSort.BookTitleDesc:
                        AddOrderByDesc(b => b.Title);
                        break;
                    default:
                        AddOrderBy(b => b.Title);
                        break;
                }
            }


            ApplyPagination(booksParams.PageSize, booksParams.PageIndex);
        }

        private static Expression<Func<Book, bool>> GetCriteria(BookParametersSpecifications booksParams)
        {
            return (b) =>
            (booksParams.CategoryId == null || b.CategoryId == booksParams.CategoryId) &&
            (string.IsNullOrWhiteSpace(booksParams.SearchByTitle) || b.Title == booksParams.SearchByTitle);

           
        }

        
    }
}

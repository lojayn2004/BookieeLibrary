using Shared.Dtos.Books.Student;

namespace Services.Specifications
{
    public class BorrowBookSpecification : Specification<BorrowBookDetails>
    {
        public BorrowBookSpecification(BorrowBookKey borrowBookKey): 
            base(b => (b.BookId ==  borrowBookKey.BookId) && (b.StudentId == borrowBookKey.StudentId))
        {
            AddInclude(b => b.Book);
        }
        
        public BorrowBookSpecification(Expression<Func<BorrowBookDetails, bool>>? Criteria) : base(Criteria)
        {
           
            AddInclude(b => b.Book);
        }
    }
}

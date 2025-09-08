



namespace Domain.Contracts
{
    public abstract class Specification<T> where T : class
    {
        public Expression<Func<T, bool>>? Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new();

        public Expression<Func<T, object>>? OrderBy { get; private set; }

        public Expression<Func<T, object>>? OrderByDesc { get; private set; }


        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginated { get; private set; }


        protected Specification(Expression<Func<T, bool>>? Criteria) => this.Criteria = Criteria;
        

        protected void AddInclude(Expression<Func<T, object>> include) => Includes.Add(include);
    
        protected void AddOrderBy(Expression<Func<T, object>> orderBy) => OrderBy = orderBy;

        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDesc) => OrderByDesc = orderByDesc;
   
    
        protected void ApplyPagination(int PageSize, int PageIndex)
        {
            Take = PageSize;
            Skip = (PageIndex - 1) * PageSize;
            IsPaginated = true;
        }
    
    }
}

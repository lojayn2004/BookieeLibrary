namespace Shared.Dtos.Books
{
    public class PaginatedResponse<TData>
    {
        public int PageSize { get; set; }

        public int PageIndex {get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<TData> Data { get; set; } = new List<TData>();
    }
}

namespace Shared.Specifications
{
    public class BookParametersSpecifications
    {
        private const int MaxPageSize = 10;
        private int _pageSize = MaxPageSize;
        public BookSort? BookSort { get; set; }

        public int? CategoryId { get; set; }

        public string? SearchByTitle { get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }  
    }

    public enum BookSort
    {
        BookTitleAsc,
        BookTitleDesc,
        BookISBNAsc,
        BookISBNDesc

    }
}

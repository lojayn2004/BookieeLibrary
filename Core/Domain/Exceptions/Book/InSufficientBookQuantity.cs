namespace Domain.Exceptions.Book
{
    public class InSufficientBookQuantity: Exception
    {
        public InSufficientBookQuantity(string isbn) : base($"Book with isbn {isbn} doesnot have sufficient Quantity") { }
    }
}

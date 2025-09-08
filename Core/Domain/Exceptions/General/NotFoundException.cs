namespace Domain.Exceptions.General
{
    public abstract class NotFoundException: Exception
    {
        public NotFoundException(string errorMsg): base(errorMsg) { }
    }
}

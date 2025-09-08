namespace Domain.Exceptions.Users
{
    public class UnAuthorizedException: Exception
    {
        public UnAuthorizedException(string message) : base(message) { }    
    }
}

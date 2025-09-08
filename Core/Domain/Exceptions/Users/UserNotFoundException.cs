
namespace Domain.Exceptions.Users
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string errorMsg) : base(errorMsg)
        {
        }
    }
}

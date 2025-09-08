using ServicesAbstraction.BookServices;
using ServicesAbstraction.UserServices;

namespace ServicesAbstraction.GeneralServices
{
    public interface IServiceManager
    {
        IBookService BookService { get;}
        IAdminBookService AdminBookService { get;}

        ICategoryService CategoryService { get;}
        IUserService UserService { get;}    

        IBorrowService BorrowService { get;}
    
    }
}

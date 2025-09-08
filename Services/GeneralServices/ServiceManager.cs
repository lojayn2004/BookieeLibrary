



using Shared.Dtos.Authorization;

namespace Services.GeneralServices
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> bookService;
        private readonly Lazy<IAdminBookService> adminBookService;
        private readonly Lazy<ICategoryService> categoryService;
        private readonly Lazy<IUserService> userService;
        private readonly Lazy<IBorrowService> borrowService;

        public ServiceManager(IUnitOfWork unitOfWork,
                              IMapper mapper,
                              IAttatchementService attatchmentService,
                              IOptions<JwtOption> options,
                             
                              UserManager<User> userManager)
        {
            bookService = new Lazy<IBookService>(() => new BookService(unitOfWork, mapper));
            adminBookService = new Lazy<IAdminBookService>(() => new AdminBookService(unitOfWork,mapper, attatchmentService));
            categoryService = new Lazy<ICategoryService>(() => new  CategoryService(unitOfWork,mapper));
            userService = new Lazy<IUserService>(() => new UserService(userManager, options));
            borrowService = new Lazy<IBorrowService>(() => new BorrowService(unitOfWork));
        }

        public IBookService BookService { get => bookService.Value;  }

        public IAdminBookService AdminBookService { get => adminBookService.Value; }

        public ICategoryService CategoryService { get => categoryService.Value;  }

        public IUserService UserService { get => userService.Value; }

        public IBorrowService BorrowService { get => borrowService.Value; }
    }
}

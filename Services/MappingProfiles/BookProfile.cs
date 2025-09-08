


using Shared.Dtos.Books.Admin;
using Shared.Dtos.Books.Student;

namespace Services.MappingProfiles
{

    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(d => d.CategoryName, (opt) => opt.MapFrom(s => s.Category.CategoryName));

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<AddBookDto, Book>();
             
       
            CreateMap<Book, AdminBookDto>().
                ForMember(d => d.CategoryName, (opt) => opt.MapFrom(s => s.Category.CategoryName));
        }
    }
}


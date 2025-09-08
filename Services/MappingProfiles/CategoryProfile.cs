

namespace Services.MappingProfiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<UpdateCategoryDto, Category>()
              .ForAllMembers(opts =>
              {
                  opts.Condition((src, dest, srcMember) => srcMember != null);
                  opts.UseDestinationValue(); 
              });
        }
    }
}

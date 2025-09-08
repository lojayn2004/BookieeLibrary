



using Shared.Dtos.Books.Admin;

namespace Services.MappingProfiles
{
    public class PictureUrlResolver(IConfiguration _configuration): IValueResolver<AddBookDto, Book, string>
    {
        public string Resolve(AddBookDto source, Book destination, string destMember, ResolutionContext context)
        {
            return $"{_configuration["BaseUrl"]}{source.PictureUrl}";
        }
    }
}

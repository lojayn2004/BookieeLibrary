

using Microsoft.AspNetCore.Http;

namespace ServicesAbstraction.GeneralServices
{
    public interface IAttatchementService
    {
        string Upload(IFormFile formFile, string folderPath);


        bool Delete(string fileName);
    }
}

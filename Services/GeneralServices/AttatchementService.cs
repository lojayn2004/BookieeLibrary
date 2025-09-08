

namespace Services.GeneralServices
{
    public class AttatchementService : IAttatchementService
    {
        private readonly List<string> _allowedExtensions = new List<string> { ".png", ".jpg", ".jpeg" };

        private const int _maxFileSize = 2_097_152;
        public string Upload(IFormFile formFile, string folderName)
        {
           
            var fileExtension = Path.GetExtension(formFile.FileName);
            if (!_allowedExtensions.Contains(fileExtension))
                throw new InvalidFileExeption("File Fomrat is not from allowed extensions (.png, .jpg, .jpeg)");

            if(_maxFileSize < formFile.Length)
                throw new InvalidFileExeption("File size exceeds max file size");

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", folderName);

            var fileName = $"{Guid.NewGuid()}_{formFile.FileName}";

            var filePath = Path.Combine(folderPath, fileName);

            using FileStream fileStream = new FileStream(filePath, FileMode.Create);

            formFile.CopyTo(fileStream);

            return filePath;
        }

        public bool Delete(string filePath)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

       
    }
}

using GalaxyApp.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace GalaxyApp.Service.Implement
{
    public class FileServices : IFileServices
    {
        public void DeleteFile(string FileName, string FolderName)
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName, FileName);

            if (File.Exists(FilePath))
                File.Delete(FilePath);
        }

        public StringBuilder DeleteSpaceFromName(string Name)
        {
            var NewName = new StringBuilder();
            var StringLen = Name.LongCount();
            for (int i = 0; i < StringLen; i++)
                NewName.Append(Name[i] == ' ' ? '_' : Name[i]);

            return NewName;
        }

        public string UploadFile(IFormFile? File, string FolderName)
        {
            if (File is null) return "null";

            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);

            string FileName = $"{Guid.NewGuid()}{DeleteSpaceFromName(File.FileName)}";

            string FilePath = Path.Combine(FolderPath, FileName);

            using var FS = new FileStream(FilePath, FileMode.Create);
            File.CopyTo(FS);

            return FilePath;
        }
    }
}

using Microsoft.AspNetCore.Http;

namespace GalaxyApp.Service.Interfaces
{
    public interface IFileServices
    {
        public string UploadFile(IFormFile File, string FolderName);
        public void DeleteFile(string FileName, string FolderName);

    }
}

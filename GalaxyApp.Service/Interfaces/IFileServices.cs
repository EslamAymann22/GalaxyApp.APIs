using Microsoft.AspNetCore.Http;
using System.Text;

namespace GalaxyApp.Service.Interfaces
{
    public interface IFileServices
    {
        public string UploadFile(IFormFile File, string FolderName);
        public void DeleteFile(string FileName, string FolderName);
        public StringBuilder DeleteSpaceFromName(string Name);

    }
}

using System.Threading.Tasks;

public interface ISharePointService
{
    Task<string> SearchFileAsync(string siteName, string fileName);
    Task<string> CreateFolderAsync(string siteName, string folderPath);
    Task<string> UploadFileAsync(string siteName, string folderPath, byte[] fileContent, string fileName);
}
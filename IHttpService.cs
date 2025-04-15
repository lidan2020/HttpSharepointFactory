using System.Threading.Tasks;

public interface IHttpService
{
    Task<(int StatusCode, string Response)> GetAsync(string url, string token = null);
    Task<(int StatusCode, string Response)> PostAsync(string url, string jsonBody, string token = null);
}
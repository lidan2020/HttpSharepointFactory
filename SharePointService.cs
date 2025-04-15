using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class SharePointService : ISharePointService
{
    private readonly IHttpService _httpService;
    private readonly string _baseUrl;
    private readonly string _token;

    public SharePointService(IHttpService httpService, string baseUrl, string token)
    {
        _httpService = httpService;
        _baseUrl = baseUrl.TrimEnd('/');
        _token = token;
    }

    public async Task<string> SearchFileAsync(string siteName, string fileName)
    {
        string url = $"{_baseUrl}/sites/{siteName}:/drive/root/search(q='{fileName}')";
        var (statusCode, response) = await _httpService.GetAsync(url, _token);
        return $"Status: {statusCode}, Response: {response}";
    }

    public async Task<string> CreateFolderAsync(string siteName, string folderPath)
    {
        string url = $"{_baseUrl}/sites/{siteName}/drive/root/children";
        var json = $"{{ "name": "{folderPath}", "folder": {{ }}, "@microsoft.graph.conflictBehavior": "rename" }}";
        var (statusCode, response) = await _httpService.PostAsync(url, json, _token);
        return $"Status: {statusCode}, Response: {response}";
    }

    public async Task<string> UploadFileAsync(string siteName, string folderPath, byte[] fileContent, string fileName)
    {
        string url = $"{_baseUrl}/sites/{siteName}/drive/root:/{folderPath}/{fileName}:/content";
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        var content = new ByteArrayContent(fileContent);
        var response = await client.PutAsync(url, content);
        var responseBody = await response.Content.ReadAsStringAsync();
        return $"Status: {(int)response.StatusCode}, Response: {responseBody}";
    }
}
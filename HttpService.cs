using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class HttpService : IHttpService
{
    private readonly HttpClient _client;

    public HttpService()
    {
        _client = new HttpClient();
    }

    public async Task<(int StatusCode, string Response)> GetAsync(string url, string token = null)
    {
        if (!string.IsNullOrEmpty(token))
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _client.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        return ((int)response.StatusCode, content);
    }

    public async Task<(int StatusCode, string Response)> PostAsync(string url, string jsonBody, string token = null)
    {
        if (!string.IsNullOrEmpty(token))
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(url, content);
        var responseContent = await response.Content.ReadAsStringAsync();
        return ((int)response.StatusCode, responseContent);
    }
}
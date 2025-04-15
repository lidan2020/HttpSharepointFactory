using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var httpService = HttpServiceFactory.Create();
        string url = "https://api.example.com/data";
        string token = "your_token";
        string json = @"{ \"query\": \"hello\" }";

        var (statusCodePost, resultPost) = await httpService.PostAsync(url, json, token);
        Console.WriteLine($"POST 状态码: {statusCodePost}\n返回: {resultPost}");
    }
}
public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public bool IsSuccess => StatusCode >= 200 && StatusCode < 300;
}
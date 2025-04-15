public static class HttpServiceFactory
{
    public static IHttpService Create()
    {
        return new HttpService();
    }
}
using Microsoft.Extensions.Configuration;
using System.IO;

public static class ProgramConfig
{
    public static ApiSettings LoadSettings()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        IConfiguration config = builder.Build();
        var settings = new ApiSettings();
        config.GetSection("ApiSettings").Bind(settings);
        return settings;
    }
}
using Microsoft.Extensions.Configuration;

public static class TestConfiguration
{
    public static IConfigurationRoot Configuration { get; }

    static TestConfiguration()
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }
}
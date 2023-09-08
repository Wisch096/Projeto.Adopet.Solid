using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings;

public static class Configurations
{
    public static AppSettings GetSettings()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        return config
            .GetSection(AppSettings.EmailSection)
            .Get<AppSettings>() ?? throw new ArgumentException("Seção não encontrada!");
    }
}

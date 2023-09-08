using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings;

public static class Configurations
{
    public static AppSettings GetSettings()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets("851ebfd4-3277-4fb8-8db4-2a6476d043ce")
            .Build();

        return config
            .GetSection(AppSettings.EmailSection)
            .Get<AppSettings>() ?? throw new ArgumentException("Seção não encontrada!");
    }
}

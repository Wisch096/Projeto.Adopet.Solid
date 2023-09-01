using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings;

public static class Configurations
{
    public static AppSettings GetSettings()
    {
        var _config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets("7dd40a68-35b5-40c1-9a17-46dbe7bb4bf6")
            .Build();

        return _config
            .GetSection(AppSettings.EmailSection)
            .Get<AppSettings>() ?? throw new ArgumentException("Seção para configuração de email não encontrada!");
    }
}

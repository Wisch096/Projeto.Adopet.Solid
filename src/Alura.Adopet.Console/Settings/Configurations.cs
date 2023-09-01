using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings;

public static class Configurations
{
    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets("7dd40a68-35b5-40c1-9a17-46dbe7bb4bf6")
            .Build();
    }

    public static MailSettings MailSettings
    {
        get
        {
            var _config = BuildConfiguration();
            return _config
                .GetSection(MailSettings.EmailSection)
                .Get<MailSettings>() ?? throw new ArgumentException("Seção para configuração de email não encontrada!");
        }
    }

    public static AdopetApiSettings ApiSettings
    {
        get
        {
            var _config = BuildConfiguration();
            return _config
                .GetSection(AdopetApiSettings.Section)
                .Get<AdopetApiSettings>() ?? throw new ArgumentException("Seção para configuração da API não encontrada!");
        }
    }
}

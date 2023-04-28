using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using Qase.DriverConfiguration;

namespace Qase.Utilities;

public class Configurator
{
    public readonly ChromeOptions Settings;
    public readonly string? BaseUrl;
    public readonly Browser Browser;

    public Configurator()
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "Resources", "appsettings.json"))
            .Build();

        var chromeOptions = config.GetSection("startArguments").Get<string[]>();
        Settings = new ChromeOptions();
        Settings.AddArguments(chromeOptions);

        var browserName = config.GetValue<string>("browser");
        Browser = Enum.Parse<Browser>(browserName!, true);

        BaseUrl = config.GetValue<string>("url");
    }
}
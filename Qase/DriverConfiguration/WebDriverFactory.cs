using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Qase.Utilities;

namespace Qase.DriverConfiguration;

public class WebDriverFactory
{
    public IWebDriver GetDriver()
    {
        IWebDriver driver;
        var configurator = new Configurator();
        var browser = configurator.Browser;

        switch (browser)
        {
            case Browser.Chrome:
                driver = new ChromeDriver(configurator.Settings);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Logger.Instance.Debug(((WebDriver) driver).AuthenticatorId);
                return driver;
            case Browser.Edge:
                driver = new EdgeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                return driver;
            case Browser.FireFox:
                driver = new FirefoxDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                return driver;
            default: throw new ArgumentException($"Browser '{browser}' is not supported yet");
        }
    }
}

public enum Browser
{
    Chrome,
    Edge,
    FireFox
}
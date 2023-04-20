using OpenQA.Selenium;
using Qase.DriverConfiguration;
using Qase.Steps;

namespace Qase.Tests.Settings;

public abstract class ErrorLoginTestSettings
{
    private IWebDriver WebDriver { get; set; }

    protected LoginPageSteps LoginPageSteps;

    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        
        LoginPageSteps = new LoginPageSteps(WebDriver);
    }

    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}
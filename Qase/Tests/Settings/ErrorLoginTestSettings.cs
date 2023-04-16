using OpenQA.Selenium;
using Qase.DriverConfiguration;
using Qase.Pages.QasePages;
using Qase.Steps;

namespace Qase.Tests.Settings;

public abstract class ErrorLoginTestSettings
{
    private static IWebDriver WebDriver { get; set; }

    protected LoginPage LoginPage { get; private set; }

    protected LoginPageSteps LoginPageSteps { get; private set; }

    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        LoginPage = new LoginPage(WebDriver);
        LoginPageSteps = new LoginPageSteps(WebDriver);
    }

    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}
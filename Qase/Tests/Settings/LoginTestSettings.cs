using OpenQA.Selenium;
using Qase.DriverConfiguration;
using Qase.Entities.TestData;
using Qase.Pages.QasePages;
using Qase.Steps;

namespace Qase.Tests.Settings;

public abstract class LoginTestSettings
{
    protected static IWebDriver WebDriver { get; private set; }

    private LoginPage LoginPage { get; set; }

    private LoginPageSteps LoginPageSteps { get; set; }

    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        LoginPage = new LoginPage(WebDriver);
        LoginPageSteps = new LoginPageSteps(WebDriver);

        LoginPageSteps
            .OpenPage()
            .UserLogin(Authentication.User().Email, Authentication.User().Password);
    }
}
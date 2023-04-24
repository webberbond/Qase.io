using OpenQA.Selenium;
using Qase.DriverConfiguration;
using Qase.Entities.TestData;
using Qase.Steps;

namespace Qase.Tests.UISettings;

public abstract class LoginTestSettings
{
    protected static IWebDriver WebDriver { get; private set; }

    private LoginPageSteps _loginPageSteps;

    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        
        _loginPageSteps = new LoginPageSteps(WebDriver);

        _loginPageSteps
            .OpenPage()
            .UserLogin(Authentication.User().Email, Authentication.User().Password);
    }
}
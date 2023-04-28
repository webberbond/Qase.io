using OpenQA.Selenium;
using Qase.DriverConfiguration;
using Qase.Entities.TestData;
using Qase.Steps;

namespace Qase.Tests.UISettings;

public class LoginTestSettings
{
    protected IWebDriver WebDriver => _webDriver;

    private IWebDriver _webDriver;

    private LoginPageSteps _loginPageSteps;
    
    private readonly Authentication _authentication;

    public LoginTestSettings()
    {
        _authentication = new Authentication();
    }

    [SetUp]
    public void SetUp()
    {
        _webDriver = new WebDriverFactory().GetDriver();
        _webDriver.Manage().Window.Maximize();
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        
        _loginPageSteps = new LoginPageSteps(WebDriver);

        _loginPageSteps
            .OpenPage()
            .UserLogin(_authentication.User().Email, _authentication.User().Password);
    }
}
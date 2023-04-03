using NUnit.Allure.Attributes;
using Qase.Pages.QasePages;
using SeleniumWrapper.Utils;

namespace Qase.Steps.QaseSteps;

public class MainPageSteps : BaseStep
{
    private LoginPage LoginPage => new(Browser);
    private MainPage MainPage => new(Browser);
    
    public MainPageSteps(Browser browser) : base(browser)
    {
    }

    [AllureStep("Open Main Page")]
    public MainPageSteps OpenSite()
    {
        MainPage.OpenPage();

        return this;
    }

    [AllureStep("Validate Main Page Is Opened Successfully")]
    public MainPageSteps ValidateIsMainPageOpened()
    {
        MainPage.IsPageOpened();

        return this;
    }

    [AllureStep("Click Login Button")]
    public MainPageSteps ClickLoginButton()
    {
        MainPage.ClickLogin();

        return this;
    }

    [AllureStep("Validate Login Page Is Opened Successfully")]
    public LoginSteps ValidateIsLoginPageOpened()
    {
        LoginPage.IsPageOpened();

        return new LoginSteps(Browser);
    }
}
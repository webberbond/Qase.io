using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class LoginPageSteps 
{
    private IWebDriver WebDriver { get; }
    
    public LoginPageSteps(IWebDriver webDriver) 
    {
        WebDriver = webDriver;
    }
    
    private LoginPage LoginPage => new(WebDriver);

    [AllureStep("Open Login Page")]
    public LoginPageSteps OpenPage()
    {
        LoginPage.OpenPage();

        return this;
    }
    
    [AllureStep("Log in with {0} and {1}")]
    public LoginPageSteps UserLogin(string email, string password)
    {
        LoginPage.InputEmail(email);
        LoginPage.InputPassword(password);
        LoginPage.SubmitButton();
        
        return this;
    }
}
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class LoginPageSteps 
{
    private readonly LoginPage _loginPage;
    
    public LoginPageSteps(IWebDriver webDriver)
    {
        _loginPage = new LoginPage(webDriver);
    }

    [AllureStep("Open Login Page")]
    public LoginPageSteps OpenPage()
    {
        _loginPage.OpenPage();

        return this;
    }
    
    [AllureStep("Log in with {0} and {1}")]
    public LoginPageSteps UserLogin(string email, string password)
    {
        _loginPage.InputEmail(email);
        _loginPage.InputPassword(password);
        _loginPage.SubmitButtonClick();
        
        return this;
    }
    
    [AllureStep("Get Error Message")]
    public string GetErrorMessage()
    {
        return _loginPage.ErrorMessageText();
    }
}
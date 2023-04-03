using OpenQA.Selenium;
using Qase.Components;
using SeleniumWrapper.Utils;

namespace Qase.Pages.QasePages;

public class LoginPage : BasePage
{
    public LoginPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//a[@class='logo']");
    
    private static LoginPageComponents LoginPageComponents => new();

    public LoginPage InputEmail(string email)
    {
        LoginPageComponents.EmailInputField.SendText(email);

        return this;
    }

    public LoginPage InputPassword(string password)
    {
        LoginPageComponents.PasswordInputField.SendText(password);

        return this;
    }

    public LoginPage SubmitButton()
    {
        LoginPageComponents.SubmitButton.Click();

        return this;
    }

    public static bool ErrorMessageDisplayed()
    {
        return LoginPageComponents.ErrorMessageField.IsDisplayed();
    }

    public static string ErrorMessageText()
    {
        return LoginPageComponents.ErrorMessageField.GetText();
    }
}
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Qase.Pages.QasePages;

public class LoginPage : BasePage
{
    public LoginPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//a[@class='logo']");

    protected override string UrlPath => "/login";
    
    private IWebElement EmailInputField => WebDriver.FindElement(By.CssSelector("#inputEmail"));
    
    private IWebElement PasswordInputField => WebDriver.FindElement(By.CssSelector("#inputPassword"));
    
    private IWebElement SubmitButton => WebDriver.FindElement(By.CssSelector("#btnLogin"));
    
    private IWebElement ErrorMessageField => WebDriver.FindElement(By.CssSelector(".form-control-feedback"));

    public LoginPage InputEmail(string email)
    {
        EmailInputField.Clear();
        EmailInputField.SendKeys(email);

        return this;
    }
    
    public LoginPage InputPassword(string password)
    {
        PasswordInputField.Clear();
        PasswordInputField.SendKeys(password);

        return this;
    }
    
    public LoginPage SubmitButtonClick()
    {
        SubmitButton.Click();

        return this;
    }
    
    public bool ErrorMessageDisplayed()
    {
        return ErrorMessageField.Displayed;
    }
    
    public string ErrorMessageText()
    {
        return ErrorMessageField.Text;
    }
}
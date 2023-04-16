using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Qase.Pages.QasePages;

public class LoginPage : BasePage
{
    public LoginPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator => By.XPath("//a[@class='logo']");

    protected override string UrlPath => "/login";

    [FindsBy(How = How.CssSelector, Using = "#inputEmail")]
    private IWebElement _emailInputField;

    [FindsBy(How = How.CssSelector, Using = "#inputPassword")]
    private IWebElement _passwordInputField;

    [FindsBy(How = How.CssSelector, Using = "#btnLogin")]
    private IWebElement _submitButton;

    [FindsBy(How = How.CssSelector, Using = ".form-control-feedback")]
    private IWebElement _errorMessageField;

    public LoginPage InputEmail(string email)
    {
        _emailInputField.Clear();
        _emailInputField.SendKeys(email);

        return this;
    }
    
    public LoginPage InputPassword(string password)
    {
        _passwordInputField.Clear();
        _passwordInputField.SendKeys(password);

        return this;
    }
    
    public LoginPage SubmitButton()
    {
        _submitButton.Click();

        return this;
    }
    
    public bool ErrorMessageDisplayed()
    {
        return _errorMessageField.Displayed;
    }
    
    public string ErrorMessageText()
    {
        return _errorMessageField.Text;
    }
}
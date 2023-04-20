using OpenQA.Selenium;

namespace Qase.Pages.QasePages;

public class LogoutPage : BasePage
{
    public LogoutPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//a[@class='logo']");
    
    protected override string UrlPath => string.Empty;

    private IWebElement ProfileButton => WebDriver.FindElement(By.XPath("//span[@class='KDFykF']"));

    private IWebElement LogoutButton => WebDriver.FindElement(By.XPath("//span[normalize-space()='Sign out']"));

    public LogoutPage OpenProfile()
    {
        ProfileButton.Click();
        
        return this;
    }
    
    public LogoutPage LogoutButtonClick()
    {
        LogoutButton.Click();
        
        return this;
    }
}
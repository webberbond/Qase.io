using OpenQA.Selenium;

namespace Qase.Pages.QasePages;

public class EnvironmentsPage : BasePage
{
    public EnvironmentsPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Environments']");
    
    protected override string UrlPath => string.Empty;
    
    private IWebElement TestEnvironmentsButton => WebDriver.FindElement(By.XPath("//span[normalize-space()='Environments']"));
    
    private IWebElement CreateNewEnvironmentButton => WebDriver.FindElement(By.XPath("//a[normalize-space()='Create new environment']"));
    
    private IWebElement EnvironmentTitleInputField => WebDriver.FindElement(By.XPath("//input[@id='title']"));
    
    private IWebElement EnvironmentSlugInputField => WebDriver.FindElement(By.XPath("//input[@id='Slug']"));
    
    private IWebElement EnvironmentDescriptionInputField => WebDriver.FindElement(By.XPath("//input[@id='Description']"));
    
    private IWebElement EnvironmentHostInputField => WebDriver.FindElement(By.XPath("//input[@id='host']"));

    private IWebElement SaveTestEnvironmentButton => WebDriver.FindElement(By.XPath("//button[normalize-space()='Create environment']"));
    
    private IWebElement EnvironmentTitle => WebDriver.FindElement(By.XPath("//a[@class='defect-title']"));

    public EnvironmentsPage OpenTestEnvironment()
    {
        TestEnvironmentsButton.Click();
        
        return this;
    }
    
    public EnvironmentsPage CreateNewEnvironmentButtonClick()
    {
        CreateNewEnvironmentButton.Click();
        
        return this;
    }
    
    public EnvironmentsPage InputEnvironmentTitle(string environmentTitle)
    {
        EnvironmentTitleInputField.SendKeys(environmentTitle);
        
        return this;
    }
    
    public EnvironmentsPage InputEnvironmentSlug(string environmentSlug)
    {
        EnvironmentSlugInputField.SendKeys(environmentSlug);
        
        return this;
    }
    
    public EnvironmentsPage InputEnvironmentDescription(string environmentDescription)
    {
        EnvironmentDescriptionInputField.SendKeys(environmentDescription);
        
        return this;
    }
    
    public EnvironmentsPage InputEnvironmentHost(string environmentHost)
    {
        EnvironmentHostInputField.SendKeys(environmentHost);
        
        return this;
    }
    
    public EnvironmentsPage SaveTestEnvironment()
    {
        SaveTestEnvironmentButton.Click();
        
        return this;
    }
    
    public string GetEnvironmentTitle()
    {
        return EnvironmentTitle.Text;
    }
}
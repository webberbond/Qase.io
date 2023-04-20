using OpenQA.Selenium;

namespace Qase.Pages.QasePages;

public class RepositoryPage : BasePage
{
    public RepositoryPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//h1[@class='fGDnu0']");
    
    protected override string UrlPath => string.Empty;
    
    private IWebElement Alert => WebDriver.FindElement(By.CssSelector("[role='alert']"));

    private IWebElement CreateTestCaseButton => WebDriver.FindElement(By.XPath("//a[@id='create-case-button']"));

    private IWebElement TitleInputField => WebDriver.FindElement(By.CssSelector("#title"));

    private IWebElement DescriptionInputField => WebDriver.FindElement(By.XPath("//input[@id='0-description']"));
    
    private IWebElement PreConditionsInputField => WebDriver.FindElement(By.XPath("//input[@id='0-preconditions']"));

    private IWebElement PostConditionsInputField => WebDriver.FindElement(By.XPath("//input[@id='0-postconditions']"));
    
    private IWebElement SaveTestCaseButton => WebDriver.FindElement(By.CssSelector("#save-case"));
    
    
    private IWebElement InfoField => WebDriver.FindElement(By.CssSelector("button[type='submit']"));

    public RepositoryPage CreateNewTestCase()
    {
        CreateTestCaseButton.Click();

        return this;
    }
    
    public RepositoryPage InputTitle(string testCaseTitle)
    {
        TitleInputField.SendKeys(testCaseTitle);

        return this;
    }
    
    public RepositoryPage InputDescription(string testCaseDescription)
    {
        DescriptionInputField.SendKeys(testCaseDescription);

        return this;
    }
    
    public RepositoryPage InputPreConditions(string testCasePreConditions)
    {
        PreConditionsInputField.SendKeys(testCasePreConditions);

        return this;
    }
    
    public RepositoryPage InputPostConditions(string testCasePostConditions)
    {
        PostConditionsInputField.SendKeys(testCasePostConditions);

        return this;
    }

    public RepositoryPage ClickSaveTestCaseButton()
    {
        SaveTestCaseButton.Click();
        
        return this;
    }

    public string GetAlertText()
    {
        return Alert.Text;
    }
}
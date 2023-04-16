using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Qase.Pages.QasePages;

public class RepositoryPage : BasePage
{
    public RepositoryPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator => By.XPath("//h1[@class='fGDnu0']");
    
    protected override string UrlPath => string.Empty;

    [FindsBy(How = How.CssSelector, Using = "[role='alert']")]
    private IWebElement _alert;
    
    [FindsBy(How = How.XPath, Using = "//a[@id='create-case-button']")]
    private IWebElement _createTestCaseButton;

    [FindsBy(How = How.CssSelector, Using = "#title")]
    private IWebElement _titleInputField;
    
    [FindsBy(How = How.XPath, Using = "//input[@id='0-description']")]
    private IWebElement _descriptionInputField;
    
    [FindsBy(How = How.XPath, Using = "//input[@id='0-preconditions']")]
    private IWebElement _preConditionsInputField;
    
    [FindsBy(How = How.XPath, Using = "//input[@id='0-postconditions']")]
    private IWebElement _postConditionsInputField;

    [FindsBy(How = How.CssSelector, Using = "#save-case")]
    private IWebElement _saveTestCaseButton;
    
    [FindsBy(How = How.CssSelector, Using = ".o0Jd8j")]
    private IWebElement _infoField;
    
    public RepositoryPage CreateNewTestCase()
    {
        _createTestCaseButton.Click();

        return this;
    }
    
    public RepositoryPage InputTitle(string testCaseTitle)
    {
        _titleInputField.SendKeys(testCaseTitle);

        return this;
    }
    
    public RepositoryPage InputDescription(string testCaseDescription)
    {
        _descriptionInputField.SendKeys(testCaseDescription);

        return this;
    }
    
    public RepositoryPage InputPreConditions(string testCasePreConditions)
    {
        _preConditionsInputField.SendKeys(testCasePreConditions);

        return this;
    }
    
    public RepositoryPage InputPostConditions(string testCasePostConditions)
    {
        _postConditionsInputField.SendKeys(testCasePostConditions);

        return this;
    }

    public RepositoryPage ClickSaveTestCaseButton()
    {
        _saveTestCaseButton.Click();
        
        return this;
    }

    public string GetAlertText()
    {
        return _alert.Text;
    }
}
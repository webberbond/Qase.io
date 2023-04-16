using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Qase.Pages.QasePages;

public class RunsPage : BasePage
{
    public RunsPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Test runs']");
    
    protected override string UrlPath => string.Empty;
    
    [FindsBy(How = How.CssSelector, Using = "a[title='Test Runs']")]
    private IWebElement _testRunsButton;

    [FindsBy(How = How.CssSelector, Using = "div[class='d-flex mt-3'] span[class='ZwgkIF']")]
    private IWebElement _startNewTestRunButton;

    [FindsBy(How = How.XPath, Using = "//input[@id='description']")]
    private IWebElement _testRunDescriptionField;
    
    [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Add/modify tests from repository']")]
    private IWebElement _addTestsFromRepositoryButton;
    
    [FindsBy(How = How.CssSelector, Using = "div[id='suite-0'] p[class='suite-title']")]
    private IWebElement _testCaseButton;
    
    [FindsBy(How = How.CssSelector, Using = "div[id='suitecase-1-checkbox'] span[class='custom-control-indicator']")]
    private IWebElement _testCaseCheckBox;
    
    [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Done']")]
    private IWebElement _doneButton;
    
    [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Start a run']")]
    private IWebElement _startRunButton;
    
    [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Complete']")]
    private IWebElement _completeConfirmButton;
    
    [FindsBy(How = How.CssSelector, Using = "#complete-run-button")]
    private IWebElement _completeRunButton;
    
    [FindsBy(How = How.CssSelector, Using = "#share-report-button")]
    private IWebElement _shareReportButton;
    
    [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Run again']")]
    private IWebElement _runAgainButton;
    
    public RunsPage OpenTestRunsPage()
    {
        _testRunsButton.Click();

        return this;
    }
    
    public RunsPage StartNewTestRun()
    {
        _startNewTestRunButton.Click();

        return this;
    }
    
    public RunsPage InputTestRunDescription(string testRunDescription)
    {
        _testRunDescriptionField.SendKeys(testRunDescription);

        return this;
    }
    
    public RunsPage AddTestsFromRepository()
    {
        _addTestsFromRepositoryButton.Click();

        return this;
    }

    public RunsPage TestCaseButtonClick()
    {
        _testCaseButton.Click();
        
        return this;
    }
    
    public RunsPage TestCaseCheckBoxClick()
    {
        _testCaseCheckBox.Click();
        
        return this;
    }
    
    public RunsPage DoneButtonClick()
    {
        _doneButton.Click();
        
        return this;
    }
    
    public RunsPage StartRunButtonClick()
    {
        _startRunButton.Click();
        
        return this;
    }

    public bool IsShareReportButtonDisplayed()
    {
       return _shareReportButton.Displayed;
    }

    public RunsPage CompleteRunButtonClick()
    {
        _completeRunButton.Click();
        
        return this;
    }
    
    public RunsPage CompleteConfirmButtonClick()
    {
        _completeConfirmButton.Click();
        
        return this;
    }

    public bool IsRunAgainButtonDisplayed()
    {
        return _runAgainButton.Displayed;
    }
}
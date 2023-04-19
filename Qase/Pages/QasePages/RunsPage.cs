using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Qase.Pages.QasePages;

public class RunsPage : BasePage
{
    public RunsPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Test runs']");
    
    protected override string UrlPath => string.Empty;

    private IWebElement TestRunsButton => WebDriver.FindElement(By.CssSelector("a[title='Test Runs']"));

    private IWebElement StartNewTestRunButton => WebDriver.FindElement(By.CssSelector("div[class='d-flex mt-3'] span[class='ZwgkIF']"));

    private IWebElement TestRunDescriptionField => WebDriver.FindElement(By.XPath("//input[@id='description']"));

    private IWebElement AddTestsFromRepositoryButton => WebDriver.FindElement(By.XPath("//button[normalize-space()='Add/modify tests from repository']"));
    
    private IWebElement TestCaseButton => WebDriver.FindElement(By.CssSelector("div[id='suite-0'] p[class='suite-title']"));

    private IWebElement TestCaseCheckBox => WebDriver.FindElement(By.CssSelector("div[id='suitecase-1-checkbox'] span[class='custom-control-indicator']"));

    private IWebElement DoneButton => WebDriver.FindElement(By.XPath("//span[normalize-space()='Done']"));

    private IWebElement StartRunButton => WebDriver.FindElement(By.XPath("//span[normalize-space()='Start a run']"));

    private IWebElement CompleteConfirmButton => WebDriver.FindElement(By.XPath("//span[normalize-space()='Complete']"));

    private IWebElement CompleteRunButton => WebDriver.FindElement(By.CssSelector("#complete-run-button"));

    private IWebElement ShareReportButton => WebDriver.FindElement(By.CssSelector("#share-report-button"));
    
    private IWebElement RunAgainButton => WebDriver.FindElement(By.XPath("//button[normalize-space()='Run again']"));
    
    public RunsPage OpenTestRunsPage()
    {
        TestRunsButton.Click();

        return this;
    }
    
    public RunsPage StartNewTestRun()
    {
        StartNewTestRunButton.Click();

        return this;
    }
    
    public RunsPage InputTestRunDescription(string testRunDescription)
    {
        TestRunDescriptionField.SendKeys(testRunDescription);

        return this;
    }
    
    public RunsPage AddTestsFromRepository()
    {
        AddTestsFromRepositoryButton.Click();

        return this;
    }

    public RunsPage TestCaseButtonClick()
    {
        TestCaseButton.Click();
        
        return this;
    }
    
    public RunsPage TestCaseCheckBoxClick()
    {
        TestCaseCheckBox.Click();
        
        return this;
    }
    
    public RunsPage DoneButtonClick()
    {
        DoneButton.Click();
        
        return this;
    }
    
    public RunsPage StartRunButtonClick()
    {
        StartRunButton.Click();
        
        return this;
    }

    public bool IsShareReportButtonDisplayed()
    {
       return ShareReportButton.Displayed;
    }

    public RunsPage CompleteRunButtonClick()
    {
        CompleteRunButton.Click();
        
        return this;
    }
    
    public RunsPage CompleteConfirmButtonClick()
    {
        CompleteConfirmButton.Click();
        
        return this;
    }

    public bool IsRunAgainButtonDisplayed()
    {
        return RunAgainButton.Displayed;
    }
}
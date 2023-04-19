using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Qase.Pages.QasePages;

public class PlansPage : BasePage
{
    public PlansPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Test plans']");
    
    protected override string UrlPath => string.Empty;
    
    private IWebElement Alert => WebDriver.FindElement(By.CssSelector("[role='alert']"));
    
    private IWebElement TestPlanTitle => WebDriver.FindElement(By.XPath("//a[@class='defect-title']"));
    
    private IWebElement TestPlansButton => WebDriver.FindElement(By.CssSelector("a[title='Test Plans']"));
    
    private IWebElement CreateTestPlanButton => WebDriver.FindElement(By.XPath("(//a[@id='createButton'])[1]"));
    
    private IWebElement TestPlanTitleInputField => WebDriver.FindElement(By.XPath("//input[@id='title']"));
    
    private IWebElement TestPlanDescriptionInputField => WebDriver.FindElement(By.XPath("//input[@type='text']"));
    
    private IWebElement AddTestCasesButton => WebDriver.FindElement(By.CssSelector("#edit-plan-add-cases-button"));
    
    private IWebElement CreatedTestCaseButton => WebDriver.FindElement(By.CssSelector("div[id='suite-0'] p[class='suite-title']"));

    private IWebElement CreatedTestCaseCheckboxButton => WebDriver.FindElement(By.CssSelector("div[id='suitecase-1-checkbox'] span[class='custom-control-indicator']"));

    private IWebElement DoneButton => WebDriver.FindElement(By.XPath("//span[normalize-space()='Done']"));
    
    private IWebElement SubmitPlanButton => WebDriver.FindElement(By.CssSelector("#save-plan"));

    public PlansPage OpenTestPlans()
    {
        TestPlansButton.Click();
        
        return this;
    }
    
    public PlansPage CreatePlanButtonClick()
    {
        CreateTestPlanButton.Click();
        
        return this;
    }
    
    public PlansPage InputTitle(string planTitle)
    {
        TestPlanTitleInputField.SendKeys(planTitle);
        
        return this;
    }
    
    public PlansPage InputDescription(string planDescription)
    {
        TestPlanDescriptionInputField.SendKeys(planDescription);
        
        return this;
    }
    
    public PlansPage AddTestCasesButtonClick()
    {
        AddTestCasesButton.Click();
        
        return this;
    }
    
    public PlansPage CreatedTestCaseButtonClick()
    {
        CreatedTestCaseButton.Click();
        
        return this;
    }
    
    public PlansPage CreatedTestCaseCheckboxButtonClick()
    {
        CreatedTestCaseCheckboxButton.Click();
        
        return this;
    }
    
    public PlansPage DoneButtonClick()
    {
        DoneButton.Click();
        
        return this;
    }
    
    public PlansPage SubmitPlanButtonClick()
    {
        SubmitPlanButton.Click();
        
        return this;
    }
    
    public string GetAlertText()
    {
        return Alert.Text;
    }
    
    public string GetTestPlanTitle()
    {
        return TestPlanTitle.Text;
    }
}
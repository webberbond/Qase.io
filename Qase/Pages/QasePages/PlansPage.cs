using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Qase.Pages.QasePages;

public class PlansPage : BasePage
{
    public PlansPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Test plans']");
    
    protected override string UrlPath => string.Empty;
    
    [FindsBy(How = How.CssSelector, Using = "[role='alert']")]
    private IWebElement _alert;

    [FindsBy(How = How.XPath, Using = "//a[@class='defect-title']")]
    private IWebElement _testPlanTitle;
    
    [FindsBy(How = How.CssSelector, Using = "a[title='Test Plans']")]
    private IWebElement _testPlansButton;
    
    [FindsBy(How = How.XPath, Using = "(//a[@id='createButton'])[1]")]
    private IWebElement _createTestPlanButton;
    
    [FindsBy(How = How.XPath, Using = "//input[@id='title']")]
    private IWebElement _testPlanTitleInputField;
    
    [FindsBy(How = How.XPath, Using = "//input[@type='text']")]
    private IWebElement _testPlanDescriptionInputField;

    [FindsBy(How = How.CssSelector, Using = "#edit-plan-add-cases-button")]
    private IWebElement _addTestCasesButton;

    [FindsBy(How = How.CssSelector, Using = "div[id='suite-0'] p[class='suite-title']")]
    private IWebElement _createdTestCaseButton;
    
    [FindsBy(How = How.CssSelector, Using = "div[id='suitecase-1-checkbox'] span[class='custom-control-indicator']")]
    private IWebElement _createdTestCaseCheckboxButton;
    
    [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Done']")]
    private IWebElement _doneButton;
    
    [FindsBy(How = How.CssSelector, Using = "#save-plan")]
    private IWebElement _submitPlanButton;

    public PlansPage OpenTestPlans()
    {
        _testPlansButton.Click();
        
        return this;
    }
    
    public PlansPage CreatePlanButtonClick()
    {
        _createTestPlanButton.Click();
        
        return this;
    }
    
    public PlansPage InputTitle(string planTitle)
    {
        _testPlanTitleInputField.SendKeys(planTitle);
        
        return this;
    }
    
    public PlansPage InputDescription(string planDescription)
    {
        _testPlanDescriptionInputField.SendKeys(planDescription);
        
        return this;
    }
    
    public PlansPage AddTestCasesButtonClick()
    {
        _addTestCasesButton.Click();
        
        return this;
    }
    
    public PlansPage CreatedTestCaseButtonClick()
    {
        _createdTestCaseButton.Click();
        
        return this;
    }
    
    public PlansPage CreatedTestCaseCheckboxButtonClick()
    {
        _createdTestCaseCheckboxButton.Click();
        
        return this;
    }
    
    public PlansPage DoneButtonClick()
    {
        _doneButton.Click();
        
        return this;
    }
    
    public PlansPage SubmitPlanButtonClick()
    {
        _submitPlanButton.Click();
        
        return this;
    }
    
    public string GetAlertText()
    {
        return _alert.Text;
    }
    
    public string GetTestPlanTitle()
    {
        return _testPlanTitle.Text;
    }
}
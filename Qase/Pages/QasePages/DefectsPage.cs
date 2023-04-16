using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Qase.Pages.QasePages;

public class DefectsPage : BasePage
{
    public DefectsPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Defects']");
    protected override string UrlPath => string.Empty;
    
    [FindsBy(How = How.XPath, Using = "//a[@id='defect-1-title']")]
    private IWebElement _defectTitle;
    
    [FindsBy(How = How.CssSelector, Using = "[role='alert']")]
    private IWebElement _alert;
    
    [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
    private IWebElement _createDefectButton;

    [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary")]
    private IWebElement _createNewDefectButton;
    
    [FindsBy(How = How.XPath, Using = "//input[@id='title']")]
    private IWebElement _defectTitleInputField;
    
    [FindsBy(How = How.XPath, Using = "//input[@id='actual_result']")]
    private IWebElement _defectActualResultInputField;
    
    [FindsBy(How = How.CssSelector, Using = "a[title='Defects']")]
    private IWebElement _defectsButton;

    public DefectsPage CreateNewDefect()
    {
        _defectsButton.Click();
        _createNewDefectButton.Click();
        
        return this;
    }
    
    public DefectsPage InputDefectTitle(string defectTitle)
    {
        _defectTitleInputField.SendKeys(defectTitle);
        
        return this;
    }
    
    public DefectsPage InputDefectActualResult(string defectActualResult)
    {
        _defectActualResultInputField.SendKeys(defectActualResult);
        
        return this;
    }
    
    public DefectsPage CreateDefect()
    {
        _createDefectButton.Click();
        
        return this;
    }

    public string GetAlertText()
    {
        return _alert.Text;
    }
    
    public string GetDefectTitle()
    {
        return _defectTitle.Text;
    }
}   
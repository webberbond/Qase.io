using OpenQA.Selenium;

namespace Qase.Pages.QasePages;

public class DefectsPage : BasePage
{
    public DefectsPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Defects']");
    
    protected override string UrlPath => string.Empty;
    
    private IWebElement DefectTitle => WebDriver.FindElement(By.XPath("//a[@id='defect-1-title']"));
    
    private IWebElement Alert => WebDriver.FindElement(By.CssSelector("[role='alert']"));
    
    private IWebElement CreateDefectButton => WebDriver.FindElement(By.CssSelector("button[type='submit']"));
    
    private IWebElement CreateNewDefectButton => WebDriver.FindElement(By.CssSelector(".btn.btn-primary"));
    
    private IWebElement DefectTitleInputField => WebDriver.FindElement(By.XPath("//input[@id='title']"));
    
    private IWebElement DefectActualResultInputField => WebDriver.FindElement(By.XPath("//input[@id='actual_result']"));
    
    private IWebElement DefectsButton => WebDriver.FindElement(By.CssSelector("a[title='Defects']"));

    public DefectsPage CreateNewDefect()
    {
        DefectsButton.Click();
        CreateNewDefectButton.Click();
        
        return this;
    }
    
    public DefectsPage InputDefectTitle(string defectTitle)
    {
        DefectTitleInputField.SendKeys(defectTitle);
        
        return this;
    }
    
    public DefectsPage InputDefectActualResult(string defectActualResult)
    {
        DefectActualResultInputField.SendKeys(defectActualResult);
        
        return this;
    }
    
    public DefectsPage CreateDefect()
    {
        CreateDefectButton.Click();
        
        return this;
    }

    public string GetAlertText()
    {
        return Alert.Text;
    }
    
    public string GetDefectTitle()
    {
        return DefectTitle.Text;
    }
}   
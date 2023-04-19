using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Qase.Pages.QasePages;

public class ProjectsPage : BasePage
{
    public ProjectsPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Projects']");
    
    protected override string UrlPath => string.Empty;

    private IWebElement AlertMessage => WebDriver.FindElement(By.CssSelector("[role='alert']"));

    private IWebElement CreateProjectButton => WebDriver.FindElement(By.CssSelector("#createButton"));
    
    private IWebElement ProjectNameInputField => WebDriver.FindElement(By.CssSelector("#project-name"));
    
    private IWebElement ProjectCodeInputField => WebDriver.FindElement(By.CssSelector("#project-code"));
    
    private IWebElement ProjectDescriptionInputField => WebDriver.FindElement(By.CssSelector("#description-area"));
    
    private IWebElement CreateProjectSubmitButton => WebDriver.FindElement(By.XPath("//span[normalize-space()='Create project']"));
    
    private IWebElement ProjectSettingsButton => WebDriver.FindElement(By.XPath("//span[normalize-space()='Settings']"));
    
    private IWebElement ProjectTitle => WebDriver.FindElement(By.XPath("//h1[@class='fGDnu0']"));
    
    private IWebElement ProjectsButton => WebDriver.FindElement(By.XPath("//a[normalize-space()='Projects']"));
    
    private IWebElement ProjectSettingsOnPage => WebDriver.FindElement(By.XPath("(//i[@class='fa fa-ellipsis-h'])[1]"));
    
    private IWebElement DeleteProjectButton => WebDriver.FindElement(By.XPath("(//button[@type='button'][normalize-space()='Delete'])[1]"));
    
    private IWebElement DeleteProjectConfirmButton => WebDriver.FindElement(By.XPath("//button[@class='j4xaa7 b_jd28 J4xngT']"));
    
    public ProjectsPage CreateNewProject()
    {
        CreateProjectButton.Click();

        return this;
    }
    
    public ProjectsPage InputProjectName(string projectName)
    {
        ProjectNameInputField.Clear();
        ProjectNameInputField.SendKeys(projectName);

        return this;
    }
    
    public ProjectsPage InputProjectCode(string projectCode)
    {
        ProjectCodeInputField.Clear();
        ProjectCodeInputField.Clear();
        ProjectCodeInputField.Clear();
        ProjectCodeInputField.SendKeys(projectCode);

        return this;
    }
    
    public ProjectsPage InputProjectDescription(string projectDescription)
    {
        ProjectDescriptionInputField.Clear();
        ProjectDescriptionInputField.SendKeys(projectDescription);

        return this;
    }

    public ProjectsPage ClickSubmitButton()
    {
        CreateProjectSubmitButton.Click();
        
        return this;
    }

    public ProjectsPage OpenProjectSettings()
    {
        ProjectSettingsButton.Click();
        
        return this;
    }
    
    public string GetProjectTitle()
    {
        return ProjectTitle.Text;
    }

    public string GetProjectName()
    {
        return ProjectNameInputField.GetAttribute("value");
    }
    
    public string GetProjectCode()
    {
        return ProjectCodeInputField.GetAttribute("value");
    }
    
    public string GetProjectDescription()
    {
        return ProjectDescriptionInputField.GetAttribute("value");
    }
    
    public ProjectsPage DeleteProject()
    {
        ProjectsButton.Click();
        ProjectSettingsOnPage.Click();
        DeleteProjectButton.Click();
        DeleteProjectConfirmButton.Click();
        
        return this;
    }
}
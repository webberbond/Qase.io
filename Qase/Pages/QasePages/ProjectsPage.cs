using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Qase.Pages.QasePages;

public class ProjectsPage : BasePage
{
    public ProjectsPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Projects']");
    
    protected override string UrlPath => string.Empty;
    
    [FindsBy(How = How.CssSelector, Using = "[role='alert']")]
    private IWebElement _alertMessage;
    
    [FindsBy(How = How.CssSelector, Using = "#createButton")]
    private IWebElement _createProjectButton;
    
    [FindsBy(How = How.CssSelector, Using = "#project-name")]
    private IWebElement _projectNameInputField;
    
    [FindsBy(How = How.CssSelector, Using = "#project-code")]
    private IWebElement _projectCodeInputField;
    
    [FindsBy(How = How.CssSelector, Using = "#description-area")]
    private IWebElement _projectDescriptionInputField;
    
    [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Create project']")]
    private IWebElement _createProjectSubmitButton;
    
    [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Settings']")]
    private IWebElement _projectSettingsButton;
    
    [FindsBy(How = How.XPath, Using = "//h1[@class='fGDnu0']")]
    private IWebElement _projectTitle;
    
    [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Projects']")]
    private IWebElement _projectsButton;
    
    [FindsBy(How = How.XPath, Using = "(//i[@class='fa fa-ellipsis-h'])[1]")]
    private IWebElement _projectSettingsOnPage;
    
    [FindsBy(How = How.XPath, Using = "(//button[@type='button'][normalize-space()='Delete'])[1]")]
    private IWebElement _deleteProjectButton;
    
    [FindsBy(How = How.XPath, Using = "//button[@class='j4xaa7 b_jd28 J4xngT']")]
    private IWebElement _deleteProjectConfirmButton;
    
    public ProjectsPage CreateNewProject()
    {
        _createProjectButton.Click();

        return this;
    }
    
    public ProjectsPage InputProjectName(string projectName)
    {
        _projectNameInputField.Clear();
        _projectNameInputField.SendKeys(projectName);

        return this;
    }
    
    public ProjectsPage InputProjectCode(string projectCode)
    {
        _projectCodeInputField.Clear();
        _projectCodeInputField.Clear();
        _projectCodeInputField.Clear();
        _projectCodeInputField.SendKeys(projectCode);

        return this;
    }
    
    public ProjectsPage InputProjectDescription(string projectDescription)
    {
        _projectDescriptionInputField.Clear();
        _projectDescriptionInputField.SendKeys(projectDescription);

        return this;
    }

    public ProjectsPage ClickSubmitButton()
    {
        _createProjectSubmitButton.Click();
        
        return this;
    }

    public ProjectsPage OpenProjectSettings()
    {
        _projectSettingsButton.Click();
        
        return this;
    }
    
    public string GetProjectTitle()
    {
        return _projectTitle.Text;
    }

    public string GetProjectName()
    {
        return _projectNameInputField.GetAttribute("value");
    }
    
    public string GetProjectCode()
    {
        return _projectCodeInputField.GetAttribute("value");
    }
    
    public string GetProjectDescription()
    {
        return _projectDescriptionInputField.GetAttribute("value");
    }
    
    public ProjectsPage DeleteProject()
    {
        _projectsButton.Click();
        _projectSettingsOnPage.Click();
        _deleteProjectButton.Click();
        _deleteProjectConfirmButton.Click();
        
        return this;
    }
}
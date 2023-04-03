using OpenQA.Selenium;
using Qase.Components;
using Qase.Entities.Models;
using SeleniumWrapper.Utils;

namespace Qase.Pages.QasePages;

public class ProjectsPage : BasePage
{
    public ProjectsPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Projects']");
    
    private static ProjectsPageComponents ProjectsPageComponents => new();

    public ProjectsPage CreateNewProject()
    {
        ProjectsPageComponents.CreateProjectButton.Click();

        return this;
    }

    public ProjectsPage InputProjectName(string projectName)
    {
        ProjectsPageComponents.ProjectNameInput.SendText(projectName);

        return this;
    }

    public ProjectsPage InputProjectCode(string projectCode)
    {
        ProjectsPageComponents.ProjectCodeInput.SendText(projectCode);

        return this;
    }

    public ProjectsPage InputProjectDescription(string projectDescription)
    {
        ProjectsPageComponents.ProjectDescriptionInput.SendText(projectDescription);

        return this;
    }

    public ProjectsPage ClickSubmitButton()
    {
        ProjectsPageComponents.CreateProjectSubmitButton.Click();

        return this;
    }

    public ProjectsPage OpenProjectSettings()
    {
        ProjectsPageComponents.ProjectSettingsButton.Click();

        return this;
    }

    public static bool CompareData(TestProjectModel expectedTestProject)
    {
        var actualTestProject = new TestProjectModel
        {
            ProjectName = ProjectsPageComponents.ProjectNameInput.GetValue(),
            ProjectCode = ProjectsPageComponents.ProjectCodeInput.GetValue(),
            ProjectDescription = ProjectsPageComponents.ProjectDescriptionInput.GetValue()
        };

        // Compare the actual project details with the expected project details
        var isMatch = actualTestProject.ProjectName == expectedTestProject.ProjectName &&
                      actualTestProject.ProjectCode == expectedTestProject.ProjectCode &&
                      actualTestProject.ProjectDescription == expectedTestProject.ProjectDescription;

        return isMatch;
    }
}
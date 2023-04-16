using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Entities.Models;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class ProjectsPageSteps
{
    private IWebDriver WebDriver { get; }
    
    public ProjectsPageSteps(IWebDriver webDriver) 
    {
        WebDriver = webDriver;
    }
    
    private ProjectsPage ProjectsPage => new(WebDriver);

    [AllureStep("Create New Project")]
    public ProjectsPageSteps CreateNewProject()
    {
        ProjectsPage.CreateNewProject();

        return this;
    }

    [AllureStep("Input Data")]
    public ProjectsPageSteps InputInformation(TestProjectModel testProject)
    {
        ProjectsPage
            .InputProjectName(testProject.ProjectName)
            .InputProjectCode(testProject.ProjectCode)
            .InputProjectDescription(testProject.ProjectDescription);

        return this;
    }
    
    [AllureStep("Click Submit Button")]
    public ProjectsPageSteps ClickSubmitButton()
    {
        ProjectsPage.ClickSubmitButton();
        
        return this;
    }
    
    [AllureStep("Open Project Settings")]
    public ProjectsPageSteps OpenProjectSettings()
    {
        ProjectsPage.OpenProjectSettings();
        
        return this;
    }
}
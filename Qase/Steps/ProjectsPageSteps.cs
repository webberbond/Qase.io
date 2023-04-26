using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using Qase.Entities.Models;
using Qase.Pages.QasePages;

namespace Qase.Steps;

public class ProjectsPageSteps
{
    private readonly ProjectsPage _projectsPage;
    public ProjectsPageSteps(IWebDriver webDriver) 
    {
        _projectsPage = new ProjectsPage(webDriver);
    }
    
    [AllureStep("Create New Project")]
    public ProjectsPageSteps CreateNewProject()
    {
        _projectsPage.CreateNewProject();

        return this;
    }

    [AllureStep("Input Data")]
    public ProjectsPageSteps InputInformation(TestProjectModel testProject)
    {
        _projectsPage
            .InputProjectName(testProject.ProjectName)
            .InputProjectCode(testProject.ProjectCode);

        return this;
    }
    
    [AllureStep("Click Submit Button")]
    public ProjectsPageSteps ClickSubmitButton()
    {
        _projectsPage.ClickSubmitButton();
        
        return this;
    }
    
    [AllureStep("Open Project Settings")]
    public ProjectsPageSteps OpenProjectSettings()
    {
        _projectsPage.OpenProjectSettings();
        
        return this;
    }
    
    [AllureStep("Get Project Title")]
    public string GetProjectTitle()
    {
        return _projectsPage.GetProjectTitle();
    }
    
    [AllureStep("Get Project Name")]
    public string GetProjectName()
    {
        return _projectsPage.GetProjectName();
    }
    
    [AllureStep("Get Project Code")]
    public string GetProjectCode()
    {
        return _projectsPage.GetProjectCode();
    }
    
    [AllureStep("Get Project Description")]
    public string GetProjectDescription()
    {
        return _projectsPage.GetProjectDescription();
    }
    
    [AllureStep("Delete project")]
    public ProjectsPageSteps DeleteProject()
    {
        _projectsPage.DeleteProject();
        
        return this;
    }
}
using FluentAssertions;
using NUnit.Allure.Attributes;
using Qase.Entities.Models;
using Qase.Pages.QasePages;
using SeleniumWrapper.Utils;

namespace Qase.Steps.QaseSteps;

public class ProjectsPageSteps : BaseStep
{
    private ProjectSettingsPage ProjectSettingsPage => new(Browser);
    private ProjectsPage ProjectsPage => new(Browser);
    
    public ProjectsPageSteps(Browser browser) : base(browser)
    {
    }

    [AllureStep("Validate Projects Page Is Opened")]
    public ProjectsPageSteps ValidateProjectsPageIsOpened()
    {
        ProjectsPage.IsPageOpened();

        return this;
    }
    
    [AllureStep("Create New Project")]
    public ProjectsPageSteps CreateNewProject()
    {
        ProjectsPage.CreateNewProject();

        return this;
    }

    [AllureStep("Input Data")]
    public ProjectsPageSteps InputData(TestProjectModel testProject)
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
    public ProjectsPageSteps OpenSettingsPage()
    {
        ProjectsPage.OpenProjectSettings();

        return this;
    }

    [AllureStep("Update Existing Project")]
    public ProjectsPageSteps UpdateProject(TestProjectModel testProjectToUpdate)
    {
        ProjectSettingsPage
            .UpdateProjectName(testProjectToUpdate.ProjectName)
            .UpdateProjectCode(testProjectToUpdate.ProjectCode)
            .UpdateProjectDescription(testProjectToUpdate.ProjectDescription)
            .ClickUpdateProjectSettingsButton();

        return this;
    }

    [AllureStep("Validate Project Was Updated Successfully")]
    public ProjectsPageSteps ValidateProjectWasUpdated()
    {
        ProjectSettingsPage.AlertDisplayed().Should().BeTrue();
        ProjectSettingsPage.AlertMessage().Should().Be("Project settings were successfully updated!");
        return this;
    }

    [AllureStep("Delete Existing Project")]
    public ProjectsPageSteps DeleteProject()
    {
        ProjectSettingsPage.WaitUntilAlertCloses();
        ProjectSettingsPage.ClickDeleteProjectButton();

        return this;
    }

    [AllureStep("Validate Project Details")]
    public ProjectsPageSteps ValidateDetails(TestProjectModel testProject)
    {
        ProjectsPage.OpenProjectSettings();
        ProjectsPage.CompareData(testProject).Should().BeTrue();
        
        return this;
    }
}
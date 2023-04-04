using OpenQA.Selenium;
using Qase.Components;
using SeleniumWrapper.Utils;

namespace Qase.Pages.QasePages;

public class ProjectSettingsPage : BasePage
{
    public ProjectSettingsPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//h1[normalize-space()='Project settings']");

    private static ProjectsPageComponents ProjectsPageComponents => new();
    
    public ProjectSettingsPage UpdateProjectName(string updatedProjectName)
    {
        ProjectsPageComponents.ProjectNameInput.SendText(updatedProjectName);

        return this;
    }

    public ProjectSettingsPage UpdateProjectCode(string updatedProjectCode)
    {
        ProjectsPageComponents.ProjectCodeInput.SendText(updatedProjectCode);

        return this;
    }

    public ProjectSettingsPage UpdateProjectDescription(string updatedProjectDescription)
    {
        ProjectsPageComponents.ProjectDescriptionInput.SendText(updatedProjectDescription);

        return this;
    }

    public ProjectSettingsPage ClickUpdateProjectSettingsButton()
    {
        ProjectsPageComponents.UpdateProjectSettingsButton.Click();

        return this;
    }

    public ProjectSettingsPage WaitUntilAlertCloses()
    {
         ProjectsPageComponents.Alert.WaitUntilCloses();
         
         return this;
    }

    public ProjectSettingsPage ClickDeleteProjectButton()
    {
        ProjectsPageComponents.DeleteProjectButton.Click();
        ProjectsPageComponents.ConfirmDeleteProjectButton.Click();

        return this;
    }

    public static bool AlertDisplayed()
    {
        return ProjectsPageComponents.Alert.IsDisplayed();
    }

    public static string AlertMessage()
    {
        return ProjectsPageComponents.Alert.AlertText();
    }
}
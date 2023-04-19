using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Steps;
using Qase.Utilities;

namespace Qase.Tests.Settings;

public abstract class ProjectsTestSettings : LoginTestSettings
{
    protected readonly TestProjectModel TestProjectModel = new TestProjectModelDataFaker().Generate();

    protected ProjectsPageSteps ProjectsPageSteps;

    [SetUp]
    public new void SetUp()
    {
        ProjectsPageSteps = new ProjectsPageSteps(WebDriver);

        ProjectsPageSteps
            .CreateNewProject()
            .InputInformation(TestProjectModel)
            .ClickSubmitButton();
    }
    
    [TearDown]
    public void TearDown()
    {
        ScreenShotter.TakeScreenshot();
        
        ProjectsPageSteps
            .OpenProjectSettings();
        
        var finishModel = new TestProjectModel
        {
            ProjectName = ProjectsPageSteps.GetProjectName(),
            ProjectCode = ProjectsPageSteps.GetProjectCode(),
            ProjectDescription = ProjectsPageSteps.GetProjectDescription()
        };
        
        Assert.That(finishModel, Is.EqualTo(TestProjectModel), "Comparing actual project data with generated");
        
        ProjectsPageSteps
            .DeleteProject();
        
        WebDriver.Quit();
    }
}
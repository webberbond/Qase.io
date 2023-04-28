using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Steps;
using Qase.Utilities;

namespace Qase.Tests.UISettings;

public class ProjectsTestSettings : LoginTestSettings
{
    private readonly TestProjectModel _testProjectModel = new TestProjectModelDataFaker().Generate();

    private ProjectsPageSteps _projectsPageSteps;

    [SetUp]
    public new void SetUp()
    {
        _projectsPageSteps = new ProjectsPageSteps(WebDriver);

        _projectsPageSteps
            .CreateNewProject()
            .InputInformation(_testProjectModel)
            .ClickSubmitButton();
    }
    
    [TearDown]
    public void TearDown()
    {
        new ScreenShotter().TakeScreenshot(WebDriver);

       _projectsPageSteps
            .OpenProjectSettings();
        
        var finishModel = new TestProjectModel
        {
            ProjectName = _projectsPageSteps.GetProjectName(),
            ProjectCode = _projectsPageSteps.GetProjectCode(),
        };
        
        Assert.That(finishModel, Is.EqualTo(_testProjectModel), "Comparing actual project data with generated");
        
        _projectsPageSteps
            .DeleteProject();
        
        WebDriver.Quit();
    }
}
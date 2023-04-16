using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Pages.QasePages;
using Qase.Steps;
using Qase.Utilities;

namespace Qase.Tests.Settings;

public class RepositoryTestSettings : LoginTestSettings
{
    private readonly TestProjectModel _testProjectModel = new TestProjectModelDataFaker().Generate();
    protected readonly TestCaseModel TestCaseModel = new TestCaseModelDataFaker().Generate();

    private ProjectsPage ProjectsPage { get; set; }

    private ProjectsPageSteps ProjectsPageSteps { get; set; }

    protected RepositoryPage RepositoryPage { get; private set; }
    
    protected RepositoryPageSteps RepositoryPageSteps { get; private set; }

    private PlansPageSteps PlansPageSteps { get; set; }

    [SetUp]
    public new void SetUp()
    {
        ProjectsPage = new ProjectsPage(WebDriver);
        ProjectsPageSteps = new ProjectsPageSteps(WebDriver);
        RepositoryPage = new RepositoryPage(WebDriver);
        RepositoryPageSteps = new RepositoryPageSteps(WebDriver);
        PlansPageSteps = new PlansPageSteps(WebDriver);
        
        ProjectsPageSteps
            .CreateNewProject()
            .InputInformation(_testProjectModel)
            .ClickSubmitButton();
        
        Assert.That(ProjectsPage.GetProjectTitle(), Does.Contain(_testProjectModel.ProjectCode), "Getting actual project title and compare it to generated");
    }

    [TearDown]
    public void TearDown()
    {
        ScreenShotter.TakeScreenshot();
        ProjectsPage.DeleteProject();
        WebDriver.Quit();
    }
}
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Pages.QasePages;
using Qase.Steps;
using Qase.Utilities;

namespace Qase.Tests.Settings;

public class RunsTestSettings : LoginTestSettings
{
    private readonly TestCaseModel _testCaseModel = new TestCaseModelDataFaker().Generate();
    private readonly TestProjectModel _testProjectModel = new TestProjectModelDataFaker().Generate();
    protected readonly TestRunsModel TestRunModel = new TestRunsModelDataFaker().Generate();
    
    private ProjectsPage ProjectsPage { get; set; }

    private ProjectsPageSteps ProjectsPageSteps { get; set; }

    private RepositoryPage RepositoryPage { get; set; }
    
    private RepositoryPageSteps RepositoryPageSteps { get; set; }

    private PlansPageSteps PlansPageSteps { get; set; }
    
    protected RunsPage RunsPage { get; private set; }
    
    protected RunsPageSteps RunsPageSteps { get; private set; }

    [SetUp]
    public new void SetUp()
    {
        ProjectsPage = new ProjectsPage(WebDriver);
        ProjectsPageSteps = new ProjectsPageSteps(WebDriver);
        RepositoryPage = new RepositoryPage(WebDriver);
        RepositoryPageSteps = new RepositoryPageSteps(WebDriver);
        PlansPageSteps = new PlansPageSteps(WebDriver);
        RunsPage = new RunsPage(WebDriver);
        RunsPageSteps = new RunsPageSteps(WebDriver);

        ProjectsPageSteps
            .CreateNewProject()
            .InputInformation(_testProjectModel)
            .ClickSubmitButton();

        RepositoryPageSteps
            .CreateNewTestCase()
            .InputInformation(_testCaseModel)
            .ClickSaveTestCaseButton();
        
        Assert.That(RepositoryPage.GetAlertText(), Is.EqualTo("Test case was created successfully!"));
    }

    [TearDown]
    public void TearDown()
    {
        ScreenShotter.TakeScreenshot();
        ProjectsPage.DeleteProject();
        WebDriver.Quit();
    }
}
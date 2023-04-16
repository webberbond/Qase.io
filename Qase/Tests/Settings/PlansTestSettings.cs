using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Pages.QasePages;
using Qase.Steps;
using Qase.Utilities;

namespace Qase.Tests.Settings;

public abstract class PlansTestSettings : LoginTestSettings
{
    private readonly TestProjectModel _testProjectModel = new TestProjectModelDataFaker().Generate();
    private readonly TestCaseModel _testCaseModel = new TestCaseModelDataFaker().Generate();
    protected readonly TestPlanModel TestPlanModel = new TestPlanModelDataFaker().Generate();

    private ProjectsPage ProjectsPage { get; set; }

    private ProjectsPageSteps ProjectsPageSteps { get; set; }

    private RepositoryPage RepositoryPage { get; set; }
    
    private RepositoryPageSteps RepositoryPageSteps { get; set; }
    
    protected PlansPage PlansPage { get; private set; }
    
    protected PlansPageSteps PlansPageSteps { get;  private set; }

    [SetUp]
    public new void SetUp()
    {
        ProjectsPage = new ProjectsPage(WebDriver);
        ProjectsPageSteps = new ProjectsPageSteps(WebDriver);
        RepositoryPage = new RepositoryPage(WebDriver);
        RepositoryPageSteps = new RepositoryPageSteps(WebDriver);
        PlansPage = new PlansPage(WebDriver);
        PlansPageSteps = new PlansPageSteps(WebDriver);
        
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
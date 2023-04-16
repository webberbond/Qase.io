using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Pages.QasePages;
using Qase.Steps;
using Qase.Utilities;

namespace Qase.Tests.Settings;

public abstract class ProjectsTestSettings : LoginTestSettings
{
    protected readonly TestProjectModel TestProjectModel = new TestProjectModelDataFaker().Generate();
    
    protected ProjectsPage ProjectsPage { get; private set; }
    
    protected ProjectsPageSteps ProjectsPageSteps { get; private set; }

    
    [SetUp]
    public new void SetUp()
    {
        ProjectsPage = new ProjectsPage(WebDriver);
        ProjectsPageSteps = new ProjectsPageSteps(WebDriver);
    }
    
    [TearDown]
    public void TearDown()
    {
        ScreenShotter.TakeScreenshot();
        ProjectsPage.DeleteProject();
        WebDriver.Quit();
    }
}
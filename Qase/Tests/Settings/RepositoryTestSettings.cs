using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Steps;

namespace Qase.Tests.Settings;

public class RepositoryTestSettings : ProjectsTestSettings
{
    private readonly TestCaseModel _testCaseModel = new TestCaseModelDataFaker().Generate();

    protected RepositoryPageSteps RepositoryPageSteps;

    [SetUp]
    public new void SetUp()
    {
        RepositoryPageSteps = new RepositoryPageSteps(WebDriver);
        
        RepositoryPageSteps
            .CreateNewTestCase()
            .InputInformation(_testCaseModel)
            .ClickSaveTestCaseButton();
        
        Assert.That(ProjectsPageSteps.GetProjectTitle(), Does.Contain(TestProjectModel.ProjectCode), "Getting actual project title and compare it to generated");
    }
}
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Steps;

namespace Qase.Tests.UISettings;

public class RepositoryTestSettings : ProjectsTestSettings
{
    private readonly TestCaseModel _testCaseModel = new TestCaseModelDataFaker().Generate();

    private RepositoryPageSteps RepositoryPageSteps;

    [SetUp]
    public new void SetUp()
    {
        RepositoryPageSteps = new RepositoryPageSteps(WebDriver);
        
        RepositoryPageSteps
            .CreateNewTestCase()
            .InputInformation(_testCaseModel)
            .ClickSaveTestCaseButton();
        
        Assert.That(RepositoryPageSteps.GetAlertText(), Is.EqualTo("Test case was created successfully!"), "Checking if alert text is correct after creating a test case.");
    }
}
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Steps;

namespace Qase.Tests.Settings;

public class RunsTestSettings : RepositoryTestSettings
{
    protected readonly TestRunsModel TestRunModel = new TestRunsModelDataFaker().Generate();

    protected RunsPageSteps RunsPageSteps;

    [SetUp]
    public new void SetUp()
    {
        RunsPageSteps = new RunsPageSteps(WebDriver);
    }
}
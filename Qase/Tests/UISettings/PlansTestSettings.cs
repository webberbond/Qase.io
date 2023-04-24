using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Steps;

namespace Qase.Tests.UISettings;

public abstract class PlansTestSettings : RepositoryTestSettings
{
    protected readonly TestPlanModel TestPlanModel = new TestPlanModelDataFaker().Generate();

    protected PlansPageSteps PlansPageSteps;

    [SetUp]
    public new void SetUp()
    {
        PlansPageSteps = new PlansPageSteps(WebDriver);
    }
}
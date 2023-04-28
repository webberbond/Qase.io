using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Steps;

namespace Qase.Tests.UISettings;

public class DefectsTestSettings : RepositoryTestSettings
{
    protected readonly DefectsModel DefectsModel = new DefectsModelDataFaker().Generate();
    
    protected DefectsPageSteps DefectsPageSteps;
    
    [SetUp]
    public new void SetUp()
    {
        DefectsPageSteps = new DefectsPageSteps(WebDriver);
    }
}
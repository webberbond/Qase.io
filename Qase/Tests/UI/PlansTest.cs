using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Tests.UISettings;

namespace Qase.Tests.UI;

[AllureNUnit]
public class PlansTest : PlansTestSettings
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Plans Test With Validations")]
    [AllureLink("Create Test Plan", "https://docs.google.com/spreadsheets/d/1C6DB7e3HMbSTp_GdMgxpdQGjAPl5_Kvc7mhINjfuhyg/edit#gid=1547098580")]
    public void TestPlanCreation()
    {
        PlansPageSteps
            .CreateNewTestPlan()
            .InputInformation(TestPlanModel)
            .AddTestCases()
            .SaveTestPlan();
        
        Assert.That(PlansPageSteps.GetTestPlanTitle(), Is.EqualTo(TestPlanModel.PlanTitle), "Checking if alert text is correct after creating a test plan.");
    }
}
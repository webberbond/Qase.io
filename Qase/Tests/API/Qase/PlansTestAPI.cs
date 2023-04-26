using System.Net;
using NUnit.Allure.Attributes;
using Qase.Tests.APISettings;

namespace Qase.Tests.API.Qase;

public class PlansTestAPI : ProjectsSettingsAPI
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Plans Test API")]
    public async Task CreatePlan()
    {
        var restResponse = await TestPlanService.CreateTestPlan(GetProjectCode(), TestPlanModel);
        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await TestPlanService.GetTestPlanByProjectCode(GetProjectCode());
    }
}
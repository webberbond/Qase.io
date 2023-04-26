using System.Net;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Tests.APISettings;

namespace Qase.Tests.API.Qase;

[AllureNUnit]
public class EnvironmentsTestAPI : ProjectsSettingsAPI
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Environments Test API")]
    public async Task CreateEnvironment()
    {
        var restResponse = await TestEnvironmentService.CreateTestEnvironment(GetProjectCode(), TestEnvironmentModel);
        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await TestEnvironmentService.GetTestEnvironmentByProjectCode(GetProjectCode());
    }
}
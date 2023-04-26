using System.Net;
using NUnit.Allure.Attributes;
using Qase.Tests.APISettings;

namespace Qase.Tests.API.Qase;

public class DefectsTestAPI : ProjectsSettingsAPI
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Defects Test API")]
    public async Task CreateDefect()
    {
        var restResponse = await TestDefectService.CreateDefect(GetProjectCode(), DefectsModel);
        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await TestDefectService.GetDefectsByProjectCode(GetProjectCode());
    }
}
﻿using System.Net;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Tests.APISettings;

namespace Qase.Tests.API.Qase;

[AllureNUnit]
public class RunsTestAPI : ProjectsSettingsAPI
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Runs Test API")]
    public async Task CreateTestRun()
    {
        var restResponse = await TestRunService.CreateTestRun(GetProjectCode(), TestRunModel);
        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await TestRunService.GetTestRunByProjectCode(GetProjectCode());
    }
}
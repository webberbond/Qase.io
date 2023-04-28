using System.Net;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Services;
using Qase.Tests.APISettings;

namespace Qase.Tests.API.Qase;

[AllureNUnit]
public class RunsTestAPI : ProjectsSettingsAPI
{
    private readonly TestRunsModel _testRunModel = new TestRunsModelDataFaker().Generate();
    private TestRunService _testRunService;
    private const string JsonSchemaPath = "Schemas/RunSchema.json";
    
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Runs Test API")]
    public async Task CreateTestRun()
    {
        _testRunService = new TestRunService();
        
        var (createdRunStatusCode, restResponse) = await _testRunService.CreateTestRun(GetProjectCode(), _testRunModel);
        Assert.That(createdRunStatusCode.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"{restResponse}");

        var (getRunStatusCode, finishModel, createdRunContent) = await _testRunService.GetTestRunByProjectCode(GetProjectCode());
        var jsonSchema = await File.ReadAllTextAsync(JsonSchemaPath);
        var isValid = SchemaValidator.ValidateResponse(createdRunContent, jsonSchema);
        
        Assert.That(getRunStatusCode, Is.EqualTo(HttpStatusCode.OK), $"{createdRunContent}");
        Assert.That(finishModel, Is.EqualTo(_testRunModel), "Comparing actual test run data with generated");
        Assert.That(isValid, Is.EqualTo(true), "Json schema validation");
    }
}
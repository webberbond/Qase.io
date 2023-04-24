using System.Net;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Services;
using Qase.Tests.APISettings;
using Qase.Utilities;

namespace Qase.Tests.API.Qase;

public class RunsTestAPI : ProjectsSettingsAPI
{
    private readonly TestRunsModel _testRunModel = new TestRunsModelDataFaker().Generate();

    [Test]
    public async Task CreateTestRun()
    {
        var restResponse = await TestRunService.CreateTestRun(GetProjectCode(), _testRunModel);
        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        
        const string jsonSchemaPath = "Schemas/RunSchema.json";
        
        var createdRun = await TestRunService.GetTestRunByProjectCode(GetProjectCode());
        var jsonResponse = createdRun.Content;
        var jsonSchema = await File.ReadAllTextAsync(jsonSchemaPath);
        
        var isValid = SchemaValidator.ValidateResponse(jsonResponse, jsonSchema);
        Assert.That(isValid, Is.EqualTo(true), "Json schema validation");
        
        var finishModel = new TestRunsModel
        {
            Title = createdRun.Data.Result.Title,
            Description = createdRun.Data.Result.Description,
        };
        
        Assert.That(finishModel, Is.EqualTo(_testRunModel), "Comparing actual run data with generated");
    }
}
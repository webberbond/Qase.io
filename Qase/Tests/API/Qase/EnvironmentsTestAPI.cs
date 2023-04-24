using System.Net;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Services;
using Qase.Tests.APISettings;
using Qase.Utilities;

namespace Qase.Tests.API.Qase;

public class EnvironmentsTestAPI : ProjectsSettingsAPI
{
    private readonly TestEnvironmentModel _testEnvironmentModel = new TestEnvironmentModelDataFaker().Generate();

    [Test]
    public async Task CreateEnvironment()
    {
        var restResponse = await TestEnvironmentService.CreateTestEnvironment(GetProjectCode(), _testEnvironmentModel);
        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        
        const string jsonSchemaPath = "Schemas/EnvironmentSchema.json";
        
        var createdEnvironment = await TestEnvironmentService.GetTestEnvironmentByProjectCode(GetProjectCode());
        var jsonResponse = createdEnvironment.Content;
        var jsonSchema = await File.ReadAllTextAsync(jsonSchemaPath);
        
        var isValid = SchemaValidator.ValidateResponse(jsonResponse, jsonSchema);
        Assert.That(isValid, Is.EqualTo(true), "Json schema validation");
        
        var finishModel = new TestEnvironmentModel
        {
            EnvironmentTitle = createdEnvironment.Data.Result.Title,
            EnvironmentDescription = createdEnvironment.Data.Result.Description,
            EnvironmentSlug = createdEnvironment.Data.Result.Slug,
            EnvironmentHost = createdEnvironment.Data.Result.Host
        };
      
        Assert.That(finishModel, Is.EqualTo(_testEnvironmentModel), "Comparing actual project data with generated");
    }
}
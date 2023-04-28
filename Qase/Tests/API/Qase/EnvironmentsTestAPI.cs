using System.Net;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Services.QaseServices;
using Qase.Tests.APISettings;

namespace Qase.Tests.API.Qase;

[AllureNUnit]
public class EnvironmentsTestAPI : ProjectsSettingsAPI
{
    private readonly TestEnvironmentModel _testEnvironmentModel = new TestEnvironmentModelDataFaker().Generate();
    private TestEnvironmentService _testEnvironmentService;
    private const string JsonSchemaPath = "Schemas/EnvironmentSchema.json";
    
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Environments Test API")]
    public async Task CreateEnvironment()
    {
        _testEnvironmentService = new TestEnvironmentService();
        
        var (createdEnvironmentStatusCode, restResponse) = await _testEnvironmentService.CreateTestEnvironment(GetProjectCode(), _testEnvironmentModel);
        Assert.That(createdEnvironmentStatusCode.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"{restResponse}");
        
        var (getEnvironmentStatusCode, finishModel, createdEnvironmentContent) = await _testEnvironmentService.GetTestEnvironmentByProjectCode(GetProjectCode());
        var jsonSchema = await File.ReadAllTextAsync(JsonSchemaPath);
        var isValid = SchemaValidator.ValidateResponse(createdEnvironmentContent, jsonSchema);
        
        Assert.That(getEnvironmentStatusCode, Is.EqualTo(HttpStatusCode.OK), $"{createdEnvironmentContent}");
        Assert.That(finishModel, Is.EqualTo(_testEnvironmentModel), "Comparing actual test environment data with generated");
        Assert.That(isValid, Is.EqualTo(true), "Json schema validation");
    }
}
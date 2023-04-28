using System.Net;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Services.QaseServices;
using Qase.Tests.APISettings;
using Qase.Utilities;

namespace Qase.Tests.API.Qase;

[AllureNUnit]
public class PlansTestAPI : ProjectsSettingsAPI
{
    private readonly TestPlanModel _testPlanModel = new TestPlanModelDataFaker().Generate();
    private TestPlanService _testPlanService;
    private const string JsonSchemaPath = "Schemas/PlanSchema.json";
    
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Plans Test API")]
    public async Task CreatePlan()
    {
        _testPlanService = new TestPlanService();
        
        var (createdPlanStatusCode, restResponse) = await _testPlanService.CreateTestPlan(GetProjectCode(), _testPlanModel);
        Assert.That(createdPlanStatusCode.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"{restResponse}");

        var (statusCode, finishModel, createdPlanContent) = await _testPlanService.GetTestPlanByProjectCode(GetProjectCode());
        var jsonSchema = await File.ReadAllTextAsync(JsonSchemaPath);
        var isValid = SchemaValidator.ValidateResponse(createdPlanContent, jsonSchema);
        
        Assert.That(statusCode, Is.EqualTo(HttpStatusCode.OK), $"{createdPlanContent}");
        Assert.That(finishModel, Is.EqualTo(_testPlanModel), "Comparing actual test plan data with generated");
        Assert.That(isValid, Is.EqualTo(true), "Json schema validation");
    }
}
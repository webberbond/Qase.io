using System.Net;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Services;
using Qase.Tests.APISettings;
using Qase.Utilities;

namespace Qase.Tests.API.Qase;

public class PlansTestAPI : ProjectsSettingsAPI
{
    private readonly TestPlanModel _testPlanModel = new TestPlanModelDataFaker().Generate();

    [Test]
    public async Task CreatePlan()
    {
        var restResponse = await TestPlanService.CreateTestPlan(GetProjectCode(), _testPlanModel);
        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        
        const string jsonSchemaPath = "Schemas/PlanSchema.json";
        
        var createdPlan = await TestPlanService.GetTestPlanByProjectCode(GetProjectCode());
        var jsonResponse = createdPlan.Content;
        var jsonSchema = await File.ReadAllTextAsync(jsonSchemaPath);
        
        
        var isValid = SchemaValidator.ValidateResponse(jsonResponse, jsonSchema);
        Assert.That(isValid, Is.EqualTo(true), "Json schema validation");
        
        var finishModel = new TestPlanModel
        {
            PlanTitle = createdPlan.Data.result.title,
            PlanDescription = createdPlan.Data.result.description,
        };
        
        Assert.That(finishModel, Is.EqualTo(_testPlanModel), "Comparing actual plan data with generated");
    }
}
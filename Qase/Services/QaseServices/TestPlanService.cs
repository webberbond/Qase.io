using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using Qase.Utilities;
using RestSharp;

namespace Qase.Services.QaseServices;

public class TestPlanService : BaseService
{
    private const string JsonSchemaPath = "Schemas/PlanSchema.json";
    public async Task<RestResponse<PlansModelAPI>> CreateTestPlan(string projectCode, TestPlanModel planModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/plan/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = planModel.PlanTitle,
            description = planModel.PlanDescription,
            cases = new List<int>(){1}
        });
        
        return await RestClient.ExecuteAsync<PlansModelAPI>(postRequest);
    }
    
    public async Task GetTestPlanByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/plan/{projectCode}/1", Method.Get);
        
        var createdPlan = await RestClient.ExecuteAsync<PlansModelAPI>(getRequest);
        
        var jsonResponse = createdPlan.Content;
        var jsonSchema = await File.ReadAllTextAsync(JsonSchemaPath);
        
        var isValid = SchemaValidator.ValidateResponse(jsonResponse, jsonSchema);
        Assert.That(isValid, Is.EqualTo(true), "Json schema validation");
        
        var finishModel = new TestPlanModel
        {
            PlanTitle = createdPlan.Data.result.title,
            PlanDescription = createdPlan.Data.result.description,
        };

        Assert.That(finishModel, Is.EqualTo(TestPlanModel), "Comparing actual plan data with generated");
    }
}
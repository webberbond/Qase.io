using System.Net;
using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using RestSharp;

namespace Qase.Services.QaseServices;

public class TestPlanService : BaseService
{
    public async Task<(RestResponse<PlansModelAPI>, string)> CreateTestPlan(string projectCode, TestPlanModel planModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/plan/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = planModel.PlanTitle,
            description = planModel.PlanDescription,
            cases = new List<int>(){1}
        });
        
        var createdPlan =  await RestClient.ExecuteAsync<PlansModelAPI>(postRequest);

        return (createdPlan, createdPlan.Content);
    }
    
    public async Task<(HttpStatusCode, TestPlanModel, string)> GetTestPlanByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/plan/{projectCode}/1", Method.Get);
    
        var createdPlan = await RestClient.ExecuteAsync<PlansModelAPI>(getRequest);

        var finishModel = new TestPlanModel
        {
            PlanTitle = createdPlan.Data.result.title,
            PlanDescription = createdPlan.Data.result.description,
        };

        return (createdPlan.StatusCode, finishModel, createdPlan.Content);
    }
}
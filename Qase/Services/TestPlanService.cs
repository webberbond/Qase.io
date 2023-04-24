using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using RestSharp;

namespace Qase.Services;

public class TestPlanService : IDisposable
{
    private static RestClient _restClient;

    public TestPlanService(RestClient restClient)
    {
        _restClient = restClient;
    }
    
    public static async Task<RestResponse<PlansModelAPI>> CreateTestPlan(string projectCode, TestPlanModel planModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/plan/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = planModel.PlanTitle,
            description = planModel.PlanDescription,
            cases = new List<int>(){1}
        });
        
        return await _restClient.ExecuteAsync<PlansModelAPI>(postRequest);
    }
    
    public static async Task<RestResponse<PlansModelAPI>> GetTestPlanByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/plan/{projectCode}/1", Method.Get);
        
        return await _restClient.ExecuteAsync<PlansModelAPI>(getRequest);
    }
    
    public void Dispose()
    {
        _restClient.Dispose();
    }
}
using Qase.Entities.Models;
using RestSharp;

namespace Qase.Services;

public class TestCaseService : IDisposable
{
    private static RestClient _restClient;

    public TestCaseService(RestClient restClient)
    {
        _restClient = restClient;
    }
    
    public static async Task<RestResponse<TestCaseModel>> CreateTestCase(string projectCode, TestCaseModel testCaseModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/case/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = testCaseModel.Title,
            description = testCaseModel.Description,
            preconditions = testCaseModel.PreConditions,
            postconditions = testCaseModel.PostConditions
        });
        
        return await _restClient.ExecuteAsync<TestCaseModel>(postRequest);
    }
    
    public static async Task<RestResponse<TestCaseModel>> GetTestCaseByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/case/{projectCode}/1", Method.Get);
        
        return await _restClient.ExecuteAsync<TestCaseModel>(getRequest);
    }
    
    public void Dispose()
    {
        _restClient.Dispose();
    }
}
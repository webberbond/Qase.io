using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using RestSharp;

namespace Qase.Services;

public class TestRunService : IDisposable
{
    private static RestClient _restClient;
    
    public TestRunService(RestClient restClient)
    {
        _restClient = restClient;
    }
    
    public static async Task<RestResponse<RunsModelApi>> CreateTestRun(string projectCode, TestRunsModel runModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/run/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = runModel.Title,
            description = runModel.Description
        });
        
        return await _restClient.ExecuteAsync<RunsModelApi>(postRequest);
    }
    
    public static async Task<RestResponse<RunsModelApi>> GetTestRunByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/run/{projectCode}/1", Method.Get);
        
        return await _restClient.ExecuteAsync<RunsModelApi>(getRequest);
    }
    
    public void Dispose()
    {
        _restClient.Dispose();
    }
}
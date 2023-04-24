using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using RestSharp;

namespace Qase.Services;

public class TestEnvironmentService : IDisposable
{
    private static RestClient _restClient;

    public TestEnvironmentService(RestClient restClient)
    {
        _restClient = restClient;
    }
    
    public static async Task<RestResponse<EnvironmentModelAPI>> CreateTestEnvironment(string projectCode, TestEnvironmentModel environmentModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/environment/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = environmentModel.EnvironmentTitle,
            description = environmentModel.EnvironmentDescription,
            slug = environmentModel.EnvironmentSlug,
            host = environmentModel.EnvironmentHost
        });
        
        return await _restClient.ExecuteAsync<EnvironmentModelAPI>(postRequest);
    }
    
    public static async Task<RestResponse<EnvironmentModelAPI>> GetTestEnvironmentByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/environment/{projectCode}/1", Method.Get);
        
        return await _restClient.ExecuteAsync<EnvironmentModelAPI>(getRequest);
    }
    
    public void Dispose()
    {
        _restClient.Dispose();
    }
}
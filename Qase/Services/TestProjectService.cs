using Qase.Entities.Models;
using RestSharp;

namespace Qase.Services;

public class TestProjectService : IDisposable
{
    private static RestClient _restClient;

    public TestProjectService(RestClient restClient)
    {
        _restClient = restClient;
    }
    
     public static async Task<RestResponse<TestProjectModel>> CreateProject(TestProjectModel testProjectModel)
    {
        var token = "88406d102e3323ae5f5e585db3eba08335d58c859d897221b15088ccba9626c1";
        
        _restClient.AddDefaultHeader("Token", token);
        _restClient.AddDefaultHeader("Accept", "application/json");
        _restClient.AddDefaultHeader("Content-Type", "application/json");
        
        var postRequest = new RestRequest("https://api.qase.io/v1/project", Method.Post)
            .AddJsonBody(new {
                title = testProjectModel.ProjectName,
                code = testProjectModel.ProjectCode,
                description = testProjectModel.ProjectDescription
            });
        
        return await _restClient.ExecuteAsync<TestProjectModel>(postRequest);
    }
    
    public static async Task<RestResponse<TestProjectModel>> GetProjectByCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/project/{projectCode}");
        
        return await _restClient.ExecuteAsync<TestProjectModel>(getRequest);
    }

    public static async Task<RestResponse<TestProjectModel>> DeleteProjectByCode(string projectCode)
    {
        var deleteRequest = new RestRequest($"https://api.qase.io/v1/project/{projectCode}", Method.Delete);
        
        return await _restClient.ExecuteAsync<TestProjectModel>(deleteRequest);
    }
    
    public void Dispose()
    {
        _restClient.Dispose();
    }
}
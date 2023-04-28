using System.Net;
using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using RestSharp;

namespace Qase.Services.QaseServices;

public class TestProjectService : BaseService
{
    public async Task<(RestResponse<TestProjectModel>,string)> CreateProject(TestProjectModel testProjectModel)
    { 
        var postRequest = new RestRequest("https://api.qase.io/v1/project", Method.Post)
            .AddJsonBody(new {
                title = testProjectModel.ProjectName,
                code = testProjectModel.ProjectCode
            });
        
        var createdProject = await RestClient.ExecuteAsync<TestProjectModel>(postRequest);

        return (createdProject, createdProject.Content);
    }
    
    public async Task<(HttpStatusCode, TestProjectModel, string)> GetProjectByCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/project/{projectCode}");
        
        var createdProject =  await RestClient.ExecuteAsync<ProjectModelAPI>(getRequest);
        
        var finishModel = new TestProjectModel
        {
            ProjectName = createdProject.Data.result.title,
            ProjectCode = createdProject.Data.result.code,
        };

        return (createdProject.StatusCode, finishModel, createdProject.Content);
    }

    public async Task<RestResponse<TestProjectModel>> DeleteProjectByCode(string projectCode)
    {
        var deleteRequest = new RestRequest($"https://api.qase.io/v1/project/{projectCode}", Method.Delete);
        
        return await RestClient.ExecuteAsync<TestProjectModel>(deleteRequest);
    }
}
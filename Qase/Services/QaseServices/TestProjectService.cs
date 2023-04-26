using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using RestSharp;

namespace Qase.Services.QaseServices;

public class TestProjectService : BaseService
{
    public async Task<RestResponse<TestProjectModel>> CreateProject(TestProjectModel testProjectModel)
    { 
        var postRequest = new RestRequest("https://api.qase.io/v1/project", Method.Post)
            .AddJsonBody(new {
                title = testProjectModel.ProjectName,
                code = testProjectModel.ProjectCode
            });
        
        return await RestClient.ExecuteAsync<TestProjectModel>(postRequest);
    }
    
    public async Task GetProjectByCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/project/{projectCode}");
        
        var createdProject =  await RestClient.ExecuteAsync<ProjectModelAPI>(getRequest);
        
        var finishModel = new TestProjectModel
        {
            ProjectName = createdProject.Data.result.title,
            ProjectCode = createdProject.Data.result.code,
        };
        
        Assert.That(finishModel, Is.EqualTo(TestProjectModel), "Comparing actual project data with generated");
    }

    public async Task<RestResponse<TestProjectModel>> DeleteProjectByCode(string projectCode)
    {
        var deleteRequest = new RestRequest($"https://api.qase.io/v1/project/{projectCode}", Method.Delete);
        
        return await RestClient.ExecuteAsync<TestProjectModel>(deleteRequest);
    }
}
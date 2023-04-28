using System.Net;
using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using RestSharp;

namespace Qase.Services;

public class TestRunService : BaseService
{
    public async Task<(RestResponse<RunsModelApi>, string)> CreateTestRun(string projectCode, TestRunsModel runModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/run/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = runModel.Title,
            description = runModel.Description
        });
        
        var createdRun = await RestClient.ExecuteAsync<RunsModelApi>(postRequest);

        return (createdRun, createdRun.Content);
    }
    
    public async Task<(HttpStatusCode, TestRunsModel, string)> GetTestRunByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/run/{projectCode}/1", Method.Get);
        
        var createdRun = await RestClient.ExecuteAsync<RunsModelApi>(getRequest);

        var finishModel = new TestRunsModel
        {
            Title = createdRun.Data.Result.Title,
            Description = createdRun.Data.Result.Description,
        };

        return (createdRun.StatusCode, finishModel, createdRun.Content);
    }
}
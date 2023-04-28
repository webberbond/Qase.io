using System.Net;
using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using RestSharp;

namespace Qase.Services.QaseServices;

public class TestEnvironmentService : BaseService
{
    public async Task<(RestResponse<EnvironmentModelAPI>, string)> CreateTestEnvironment(string projectCode, TestEnvironmentModel environmentModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/environment/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = environmentModel.EnvironmentTitle,
            description = environmentModel.EnvironmentDescription,
            slug = environmentModel.EnvironmentSlug,
            host = environmentModel.EnvironmentHost
        });
        
        var createdEnvironment = await RestClient.ExecuteAsync<EnvironmentModelAPI>(postRequest);

        return (createdEnvironment, createdEnvironment.Content);
    }
    
    public async Task<(HttpStatusCode, TestEnvironmentModel, string)> GetTestEnvironmentByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/environment/{projectCode}/1", Method.Get);
        
        var createdEnvironment =  await RestClient.ExecuteAsync<EnvironmentModelAPI>(getRequest);
        
        var finishModel = new TestEnvironmentModel
        {
            EnvironmentTitle = createdEnvironment.Data.Result.Title,
            EnvironmentDescription = createdEnvironment.Data.Result.Description,
            EnvironmentSlug = createdEnvironment.Data.Result.Slug,
            EnvironmentHost = createdEnvironment.Data.Result.Host
        };

        return (createdEnvironment.StatusCode, finishModel, createdEnvironment.Content);
    }
}
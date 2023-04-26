using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using Qase.Utilities;
using RestSharp;

namespace Qase.Services;

public class TestRunService : BaseService
{
    private const string JsonSchemaPath = "Schemas/RunSchema.json";
    public async Task<RestResponse<RunsModelApi>> CreateTestRun(string projectCode, TestRunsModel runModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/run/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = runModel.Title,
            description = runModel.Description
        });
        
        return await RestClient.ExecuteAsync<RunsModelApi>(postRequest);
    }
    
    public async Task GetTestRunByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/run/{projectCode}/1", Method.Get);
        
        var createdRun = await RestClient.ExecuteAsync<RunsModelApi>(getRequest);
        
        var jsonResponse = createdRun.Content;
        var jsonSchema = await File.ReadAllTextAsync(JsonSchemaPath);
        
        var isValid = SchemaValidator.ValidateResponse(jsonResponse, jsonSchema);
        Assert.That(isValid, Is.EqualTo(true), "Json schema validation");
        
        var finishModel = new TestRunsModel
        {
            Title = createdRun.Data.Result.Title,
            Description = createdRun.Data.Result.Description,
        };
        
        Assert.That(finishModel, Is.EqualTo(TestRunModel), "Comparing actual run data with generated");
    }
}
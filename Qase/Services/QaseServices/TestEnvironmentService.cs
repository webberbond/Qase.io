using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using Qase.Utilities;
using RestSharp;

namespace Qase.Services.QaseServices;

public class TestEnvironmentService : BaseService
{
    private const string JsonSchemaPath = "Schemas/EnvironmentSchema.json";
    
    public async Task<RestResponse<EnvironmentModelAPI>> CreateTestEnvironment(string projectCode, TestEnvironmentModel environmentModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/environment/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = environmentModel.EnvironmentTitle,
            description = environmentModel.EnvironmentDescription,
            slug = environmentModel.EnvironmentSlug,
            host = environmentModel.EnvironmentHost
        });
        
        return await RestClient.ExecuteAsync<EnvironmentModelAPI>(postRequest);
    }
    
    public async Task GetTestEnvironmentByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/environment/{projectCode}/1", Method.Get);
        
        var createdEnvironment =  await RestClient.ExecuteAsync<EnvironmentModelAPI>(getRequest);
        
        var jsonResponse = createdEnvironment.Content;
        var jsonSchema = await File.ReadAllTextAsync(JsonSchemaPath);
        
        var isValid = SchemaValidator.ValidateResponse(jsonResponse, jsonSchema);
        Assert.That(isValid, Is.EqualTo(true), "Json schema validation");
        
        var finishModel = new TestEnvironmentModel
        {
            EnvironmentTitle = createdEnvironment.Data.Result.Title,
            EnvironmentDescription = createdEnvironment.Data.Result.Description,
            EnvironmentSlug = createdEnvironment.Data.Result.Slug,
            EnvironmentHost = createdEnvironment.Data.Result.Host
        };
      
        Assert.That(finishModel, Is.EqualTo(TestEnvironmentModel), "Comparing actual project data with generated");
    }
}
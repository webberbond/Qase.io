using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using RestSharp;

namespace Qase.Services.QaseServices;

public class TestCaseService : BaseService
{
    public async Task<RestResponse<TestCaseModel>> CreateTestCase(string projectCode, TestCaseModel testCaseModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/case/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = testCaseModel.Title,
            description = testCaseModel.Description,
            preconditions = testCaseModel.PreConditions,
            postconditions = testCaseModel.PostConditions
        });
        
        return await RestClient.ExecuteAsync<TestCaseModel>(postRequest);
    }
    
    public async Task GetTestCaseByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/case/{projectCode}/1", Method.Get);
        
        var createdCase =  await RestClient.ExecuteAsync<CaseModelAPI>(getRequest);

        var finishModel = new TestCaseModel
        {
            Title = createdCase.Data.result.title,
            Description = createdCase.Data.result.description,
            PreConditions = createdCase.Data.result.preconditions,
            PostConditions = createdCase.Data.result.postconditions
        };
        
        Assert.That(finishModel, Is.EqualTo(TestCaseModel));
    }
}
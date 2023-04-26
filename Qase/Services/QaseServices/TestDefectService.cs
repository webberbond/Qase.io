using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using Qase.Utilities;
using RestSharp;

namespace Qase.Services.QaseServices;

public class TestDefectService : BaseService
{
    private const string JsonSchemaPath = "Schemas/DefectSchema.json";
    
    public async Task<RestResponse<DefectModelAPI>> CreateDefect(string projectCode, DefectsModel defectsModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/defect/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = defectsModel.DefectTitle,
            actual_result = defectsModel.ActualResult,
            severity = defectsModel.Severity
        });
        
        return await RestClient.ExecuteAsync<DefectModelAPI>(postRequest);
    }
    
    public async Task GetDefectsByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/defect/{projectCode}/1", Method.Get);
        
        var createdDefect =  await RestClient.ExecuteAsync<DefectModelAPI>(getRequest);
        
        var jsonResponse = createdDefect.Content;
        var jsonSchema = await File.ReadAllTextAsync(JsonSchemaPath);

        var isValid = SchemaValidator.ValidateResponse(jsonResponse, jsonSchema);
        Assert.That(isValid, Is.EqualTo(true), "Json schema validation");
        
        var finishModel = new DefectsModel
        {
            DefectTitle = createdDefect.Data.result.title,
            ActualResult = createdDefect.Data.result.actual_result
        };
        
        Assert.That(finishModel, Is.EqualTo(DefectsModel), "Comparing actual defect data with generated");
    }
}
using System.Net;
using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using RestSharp;

namespace Qase.Services.QaseServices;

public class TestDefectService : BaseService
{
    public async Task<(RestResponse<DefectModelAPI>, string)> CreateDefect(string projectCode, DefectsModel defectsModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/defect/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = defectsModel.DefectTitle,
            actual_result = defectsModel.ActualResult,
            severity = defectsModel.Severity
        });
        
        var createdDefect =  await RestClient.ExecuteAsync<DefectModelAPI>(postRequest);

        return (createdDefect, createdDefect.Content);
    }
    
    public async Task<(HttpStatusCode, DefectsModel, string)> GetDefectsByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/defect/{projectCode}/1", Method.Get);
        
        var createdDefect =  await RestClient.ExecuteAsync<DefectModelAPI>(getRequest);

        var finishModel = new DefectsModel
        {
            DefectTitle = createdDefect.Data.result.title,
            ActualResult = createdDefect.Data.result.actual_result
        };

        return (createdDefect.StatusCode, finishModel, createdDefect.Content);
    }
}
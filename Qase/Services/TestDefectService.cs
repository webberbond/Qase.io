using Qase.Entities.Models;
using Qase.Entities.ResponseModels;
using RestSharp;

namespace Qase.Services;

public class TestDefectService : IDisposable
{
    private static RestClient _restClient;

    public TestDefectService(RestClient restClient)
    {
        _restClient = restClient;
    }
    
    public static async Task<RestResponse<DefectModelAPI>> CreateDefect(string projectCode, DefectsModel defectsModel)
    {
        var postRequest = new RestRequest($"https://api.qase.io/v1/defect/{projectCode}", Method.Post).AddJsonBody(new
        {
            title = defectsModel.DefectTitle,
            actual_result = defectsModel.ActualResult,
            severity = defectsModel.Severity
        });
        
        return await _restClient.ExecuteAsync<DefectModelAPI>(postRequest);
    }
    
    public static async Task<RestResponse<DefectModelAPI>> GetDefectsByProjectCode(string projectCode)
    {
        var getRequest = new RestRequest($"https://api.qase.io/v1/defect/{projectCode}/1", Method.Get);
        
        return await _restClient.ExecuteAsync<DefectModelAPI>(getRequest);
    }

    public void Dispose()
    {
        _restClient.Dispose();
    }
}
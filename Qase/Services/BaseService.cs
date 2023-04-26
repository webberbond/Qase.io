using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using RestSharp;

namespace Qase.Services;

public abstract class BaseService
{
    protected readonly RestClient RestClient;
    protected static readonly DefectsModel DefectsModel = new DefectsModelDataFaker().Generate();
    protected static readonly TestEnvironmentModel TestEnvironmentModel = new TestEnvironmentModelDataFaker().Generate();
    protected static readonly TestPlanModel TestPlanModel = new TestPlanModelDataFaker().Generate();
    protected static readonly TestRunsModel TestRunModel = new TestRunsModelDataFaker().Generate();
    protected static readonly TestProjectModel TestProjectModel = new TestProjectModelDataFaker().Generate();
    protected static readonly TestCaseModel TestCaseModel = new TestCaseModelDataFaker().Generate();

    
    protected BaseService()
    {
        RestClient = new RestClient();
        var token = "88406d102e3323ae5f5e585db3eba08335d58c859d897221b15088ccba9626c1";
        
        RestClient.AddDefaultHeader("token", token);
    }
}
using Qase.Services;
using Qase.Services.QaseServices;
using RestSharp;

namespace Qase.Tests.API;

public class ApiBaseTest : BaseService
{
    private RestClient _restClient;

    protected TestProjectService TestProjectService;

    protected TestCaseService TestCaseService;

    protected TestDefectService TestDefectService;

    protected TestEnvironmentService TestEnvironmentService;

    protected TestPlanService TestPlanService;

    protected TestRunService TestRunService;

    [OneTimeSetUp]
    public void SetUpClient()
    {
        _restClient = new RestClient();

        TestProjectService = new TestProjectService();
        
        TestCaseService = new TestCaseService();
        
        TestDefectService = new TestDefectService();
        
        TestEnvironmentService = new TestEnvironmentService();
        
        TestPlanService = new TestPlanService();
        
        TestRunService = new TestRunService();
    }

    [OneTimeTearDown]
    public void DisposeClient()
    {
        _restClient.Dispose();
    }
}
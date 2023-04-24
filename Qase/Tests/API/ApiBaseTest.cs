using Qase.Services;
using RestSharp;

namespace Qase.Tests.API;

public class ApiBaseTest
{
    private RestClient _restClient;

    private TestProjectService TestProjectService { get; set; }

    private TestCaseService TestCaseService { get; set; }

    private TestDefectService TestDefectService { get; set; }

    private TestEnvironmentService TestEnvironmentService { get; set; }

    private TestPlanService TestPlanService { get; set; }

    private TestRunService TestRunService { get; set; }

    [OneTimeSetUp]
    public void SetUpClient()
    {
        _restClient = new RestClient();

        TestProjectService = new TestProjectService(_restClient);
        
        TestCaseService = new TestCaseService(_restClient);
        
        TestDefectService = new TestDefectService(_restClient);
        
        TestEnvironmentService = new TestEnvironmentService(_restClient);
        
        TestPlanService = new TestPlanService(_restClient);
        
        TestRunService = new TestRunService(_restClient);
    }

    [OneTimeTearDown]
    public void DisposeClient()
    {
        _restClient.Dispose();
    }
}
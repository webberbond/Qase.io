using System.Net;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Tests.API;

namespace Qase.Tests.APISettings;

public class ProjectsSettingsAPI : ApiBaseTest
{
    private readonly TestProjectModel _testProjectModel = new TestProjectModelDataFaker().Generate();
    private readonly TestCaseModel _testCaseModel = new TestCaseModelDataFaker().Generate();
    
    
    [SetUp]
    public async Task CreateProject()
    {
        var (createdProjectStatusCode, projectResponse) = await TestProjectService.CreateProject(_testProjectModel);
        Assert.That(createdProjectStatusCode.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"{projectResponse}");
        
        var (getProjectStatusCode, testProjectFinishModel, createdProjectContent) = await TestProjectService.GetProjectByCode(GetProjectCode());
        Assert.That(getProjectStatusCode, Is.EqualTo(HttpStatusCode.OK), $"{createdProjectContent}");
        Assert.That(testProjectFinishModel, Is.EqualTo(_testProjectModel), "Comparing actual test project data with generated");
        
        var (createdCaseStatusCode, caseResponse) = await TestCaseService.CreateTestCase(GetProjectCode() ,_testCaseModel);
        Assert.That(createdCaseStatusCode.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"{caseResponse}");
        
        var (getCaseStatusCode, testCaseFinishModel, createdCaseContent) = await TestCaseService.GetTestCaseByProjectCode(GetProjectCode());
        Assert.That(getCaseStatusCode, Is.EqualTo(HttpStatusCode.OK), $"{createdCaseContent}");
        Assert.That(testCaseFinishModel, Is.EqualTo(_testCaseModel), "Comparing actual test case data with generated");
    }
    
    [TearDown]
    public async Task DeleteProject()
    {
        var projectResponse = await TestProjectService.DeleteProjectByCode(GetProjectCode());
        Assert.That(projectResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
    
    protected string GetProjectCode()
    {
        return _testProjectModel.ProjectCode;
    }
}
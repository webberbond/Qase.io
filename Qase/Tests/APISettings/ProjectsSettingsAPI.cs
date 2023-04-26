using System.Net;
using Qase.Tests.API;

namespace Qase.Tests.APISettings;

public class ProjectsSettingsAPI : ApiBaseTest
{
    [SetUp]
    public async Task CreateProject()
    {
        var restResponse = await TestProjectService.CreateProject(TestProjectModel);
        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        
        await TestProjectService.GetProjectByCode(GetProjectCode());
        
        var restResponse2 = await TestCaseService.CreateTestCase(GetProjectCode() ,TestCaseModel);
        Assert.That(restResponse2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        
        await TestCaseService.GetTestCaseByProjectCode(GetProjectCode());
    }
    
    [TearDown]
    public async Task DeleteProject()
    {
        var restResponse = await TestProjectService.DeleteProjectByCode(GetProjectCode());
        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
    
    protected string GetProjectCode()
    {
        return TestProjectModel.ProjectCode;
    }
}
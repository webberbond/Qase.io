using System.Net;
using Qase.Entities.DataFaker;
using Qase.Entities.Models;
using Qase.Services;
using Qase.Tests.API;

namespace Qase.Tests.APISettings;

public class ProjectsSettingsAPI : ApiBaseTest
{
    private static readonly TestProjectModel TestProjectModel = new TestProjectModelDataFaker().Generate();
    private static readonly TestCaseModel TestCaseModel = new TestCaseModelDataFaker().Generate();

    [SetUp]
    public async Task CreateProject()
    {
        var restResponse = await TestProjectService.CreateProject(TestProjectModel);

        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        
        var restResponse1 = await TestProjectService.GetProjectByCode(GetProjectCode());
        

        // var aaa = JsonConvert.DeserializeObject<JObject>(restResponse1.Content);
        //
        // var finishModel = new TestProjectModel
        // {
        //     ProjectName = restResponse1.Data.ProjectName,
        //     ProjectCode = restResponse1.Data.ProjectCode,
        //     ProjectDescription = restResponse1.Data.ProjectDescription
        // };
        //
        // Assert.That(finishModel, Is.EqualTo(_testProjectModel), "Comparing actual project data with generated");
        
        var restResponse11 = await TestCaseService.CreateTestCase(GetProjectCode() ,TestCaseModel);
        Assert.That(restResponse11.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        
        var restResponse12 = await TestCaseService.GetTestCaseByProjectCode(GetProjectCode());
        Assert.That(restResponse12.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
    
    [TearDown]
    public async Task DeleteProject()
    {
        var restResponse = await TestProjectService.DeleteProjectByCode(GetProjectCode());
        Assert.That(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
    
    protected static string GetProjectCode()
    {
        return TestProjectModel.ProjectCode;
    }
}
using Qase.Services;
using Qase.Services.QaseServices;
using Qase.Utilities;

namespace Qase.Tests.API;

public class ApiBaseTest : BaseService
{
    protected TestProjectService TestProjectService;

    protected TestCaseService TestCaseService;

    protected SchemaValidator SchemaValidator;

    [OneTimeSetUp]
    public void SetUpClient()
    {
        TestProjectService = new TestProjectService();
        
        TestCaseService = new TestCaseService();

        SchemaValidator = new SchemaValidator();
    }
}
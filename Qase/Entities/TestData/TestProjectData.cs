using Qase.Entities.Models;

namespace Qase.Entities.TestData;

public class TestProjectData
{
    public TestProjectModel ProjectDetails()
    {
        return new TestProjectModel
        {
            ProjectName = "TestProject",
            ProjectCode = "ewewe"
        };
    }
}
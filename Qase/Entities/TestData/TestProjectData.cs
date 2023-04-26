using Qase.Entities.Models;

namespace Qase.Entities.TestData;

public static class TestProjectData
{
    public static TestProjectModel ProjectDetails()
    {
        return new TestProjectModel
        {
            ProjectName = "TestProject",
            ProjectCode = "ewewe"
        };
    }
}
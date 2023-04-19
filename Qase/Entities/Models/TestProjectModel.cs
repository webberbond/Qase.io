namespace Qase.Entities.Models;

public class TestProjectModel
{
    public string ProjectName { get; set; }
    public string ProjectCode { get; set; }
    public string ProjectDescription { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (TestProjectModel)obj;

        if (ProjectName != other.ProjectName)
        {
            throw new AssertionException($"Project name does not match. Expected: {ProjectName}, Actual: {other.ProjectName}");
        }

        if (ProjectCode != other.ProjectCode)
        {
            throw new AssertionException($"Project code does not match. Expected: {ProjectCode}, Actual: {other.ProjectCode}");
        }

        if (ProjectDescription != other.ProjectDescription)
        {
            throw new AssertionException($"Project description does not match. Expected: {ProjectDescription}, Actual: {other.ProjectDescription}");
        }

        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ProjectName, ProjectCode, ProjectDescription);
    }
}


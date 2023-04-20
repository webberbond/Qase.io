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

        return ProjectName == other.ProjectName &&
               ProjectCode == other.ProjectCode &&
               ProjectDescription == other.ProjectDescription;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ProjectName, ProjectCode, ProjectDescription);
    }

    public override string ToString()
    {
        return $"TestProjectModel: ProjectName='{ProjectName}', ProjectCode='{ProjectCode}', ProjectDescription='{ProjectDescription}'";
    }
}

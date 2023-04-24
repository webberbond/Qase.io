using Newtonsoft.Json;

namespace Qase.Entities.Models;

public class TestRunsModel
{
    [JsonProperty("title")] public string Title { get; set; }
    
    [JsonProperty("description")] public string Description { get; set; }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (TestRunsModel)obj;

        return Title == other.Title &&
               Description == other.Description;
    }
    
    public override string ToString()
    {
        return $"TestRunsModel: Title='{Title}', Description='{Description}'";
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Description);
    }
}
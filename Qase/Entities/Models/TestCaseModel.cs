using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Qase.Entities.Models;

public class TestCaseModel
{
    [JsonProperty("title")] public string Title { get; set; }

    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("preconditions")] public string PreConditions { get; set; }

    [JsonProperty("postconditions")] public string PostConditions { get; set; }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (TestCaseModel)obj;

        return Title == other.Title &&
               Description == other.Description &&
               PreConditions == other.PreConditions &&
               PostConditions == other.PostConditions;
    }

    public override string ToString()
    {
        return $"TestCaseModel: Title: {Title}, Description: {Description}, PreConditions: {PreConditions}, PostConditions: {PostConditions}'";
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Description, PreConditions, PostConditions);
    }
}
using Newtonsoft.Json;

namespace Qase.Entities.Models;

public class DefectsModel
{
    [JsonProperty("title")] public string DefectTitle { get; set; }

    [JsonProperty("actual_result")] public string ActualResult { get; set; }
    
    [JsonProperty("severity")] public string Severity { get; set; }
     
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (DefectsModel)obj;

        return DefectTitle == other.DefectTitle &&
               ActualResult == other.ActualResult;
    }

    public override string ToString()
    {
        return $"DefectsModel: DefectTitle='{DefectTitle}', ActualResult='{ActualResult}'";
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(DefectTitle, ActualResult, Severity);
    }
}

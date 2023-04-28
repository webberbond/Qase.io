using Newtonsoft.Json;
using Qase.Entities.ResponseModels;

namespace Qase.Entities.Models;

public class TestPlanModel
{
    [JsonProperty("title")] public string PlanTitle { get; set; }

    [JsonProperty("description")] public string PlanDescription { get; set; }
    
    [JsonProperty("cases")] public List<Case> Cases { get; set; }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (TestPlanModel)obj;

        return PlanTitle == other.PlanTitle &&
               PlanDescription == other.PlanDescription;
    }
    
    public override string ToString()
    {
        return $"TestPlanModel: PlanTitle='{PlanTitle}', PlanDescription='{PlanDescription}'";
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(PlanTitle, PlanDescription, Cases);
    }
}
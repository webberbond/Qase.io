using Newtonsoft.Json;

namespace Qase.Entities.Models;

public class TestEnvironmentModel
{
    [JsonProperty("title")] public string EnvironmentTitle { get; set; }

    [JsonProperty("slug")] public string EnvironmentSlug { get; set; }
    
    [JsonProperty("description")] public string EnvironmentDescription { get; set; }
    
    [JsonProperty("host")] public string EnvironmentHost { get; set; }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (TestEnvironmentModel)obj;

        return EnvironmentTitle == other.EnvironmentTitle &&
               EnvironmentSlug == other.EnvironmentSlug &&
               EnvironmentDescription == other.EnvironmentDescription &&
               EnvironmentHost == other.EnvironmentHost;
    }

    public override string ToString()
    {
        return $"TestEnvironmentModel: EnvironmentTitle='{EnvironmentTitle}', EnvironmentSlug='{EnvironmentSlug}', EnvironmentDescription='{EnvironmentDescription}', EnvironmentHost='{EnvironmentHost}'";
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(EnvironmentTitle, EnvironmentSlug, EnvironmentDescription, EnvironmentHost);
    }
}
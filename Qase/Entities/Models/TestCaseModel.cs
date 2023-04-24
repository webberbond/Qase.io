using Newtonsoft.Json;

namespace Qase.Entities.Models;

public class TestCaseModel
{
    [JsonProperty("title")] public string Title { get; set; }

    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("preconditions")] public string PreConditions { get; set; }

    [JsonProperty("postconditions")] public string PostConditions { get; set; }
}
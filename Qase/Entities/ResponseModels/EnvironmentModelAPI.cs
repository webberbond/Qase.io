using Newtonsoft.Json;

namespace Qase.Entities.ResponseModels;

public class EnvironmentModelAPI
{
    [JsonProperty("status")]
    public bool Status { get; set; }

    [JsonProperty("result")]
    public EnvironmentResult Result { get; set; }
}

public class EnvironmentResult
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("host")]
    public string Host { get; set; }
}
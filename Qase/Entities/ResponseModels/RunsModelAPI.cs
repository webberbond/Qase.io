using Newtonsoft.Json;

namespace Qase.Entities.ResponseModels;

 public class RunsModelApi
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("result")]
        public RunResult Result { get; set; }
    }

    public class RunResult
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("status_text")]
        public string StatusText { get; set; }

        [JsonProperty("start_time")]
        public DateTimeOffset StartTime { get; set; }

        [JsonProperty("end_time")]
        public object EndTime { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("time_spent")]
        public long TimeSpent { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("environment")]
        public object Environment { get; set; }

        [JsonProperty("milestone")]
        public object Milestone { get; set; }

        [JsonProperty("custom_fields")]
        public object[] CustomFields { get; set; }

        [JsonProperty("tags")]
        public object[] Tags { get; set; }
    }

    public class Stats
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("untested")]
        public long Untested { get; set; }

        [JsonProperty("passed")]
        public long Passed { get; set; }

        [JsonProperty("failed")]
        public long Failed { get; set; }

        [JsonProperty("blocked")]
        public long Blocked { get; set; }

        [JsonProperty("skipped")]
        public long Skipped { get; set; }

        [JsonProperty("retest")]
        public long Retest { get; set; }

        [JsonProperty("in_progress")]
        public long InProgress { get; set; }

        [JsonProperty("invalid")]
        public long Invalid { get; set; }
    }
using Newtonsoft.Json;

namespace ChartMogul.API.Models.Import
{
    public class PlanModel
    {
        [JsonIgnore]
        public string Uuid { get; set; }

        [JsonProperty(PropertyName = "data_source_uuid")]
        public string DataSource { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "interval_count")]
        public int IntervalCount { get; set; }

        [JsonProperty(PropertyName = "interval_unit")]
        public string InvervalUnit { get; set; }

        [JsonProperty(PropertyName = "external_id")]
        public string ExternalId { get; set; }
    }
}

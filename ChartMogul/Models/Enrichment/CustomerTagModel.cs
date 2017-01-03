using Newtonsoft.Json;

namespace ChartMogul.API.Models.Enrichment
{
    public class CustomerTagModel
    {
        [JsonProperty(PropertyName = "tags")]
        public string[] Tags { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}

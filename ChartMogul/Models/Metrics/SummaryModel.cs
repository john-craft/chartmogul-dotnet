using Newtonsoft.Json;


namespace ChartMogul.API.Models.Metrics
{
    public class SummaryModel
    {
        [JsonProperty(PropertyName = "current")]
        public int Current { get; set; }

        [JsonProperty(PropertyName = "previous")]
        public int Previous { get; set; }

        [JsonProperty(PropertyName = "percentage-change")]
        public decimal PercentageChange { get; set; }
    }
}

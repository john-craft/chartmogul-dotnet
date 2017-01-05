using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace ChartMogul.API.Models.Metrics
{   
    public class MRRChurnRateEntry
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "mrr-churn-rate")]
        public decimal MRRChurnRate { get; set; }
    }

    public class MRRChurnRateModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<MRRChurnRateEntry> Entries { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public SummaryModel Summary { get; set; }
    }

}

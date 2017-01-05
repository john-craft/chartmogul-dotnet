using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace ChartMogul.API.Models.Metrics
{
    public class ARPAEntry
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "arpa")]
        public int Arpa { get; set; }
    }

    public class ARPAModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<ARPAEntry> Entries { get; set; }
        [JsonProperty(PropertyName = "summary")]
        public SummaryModel Summary { get; set; }
    }
}

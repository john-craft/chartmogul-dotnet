using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace ChartMogul.API.Models.Metrics
{
    public class ARREntry
    {
        [JsonProperty(PropertyName= "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "arr")]
        public int Arr { get; set; }
    }

    public class ARRModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<ARREntry> Entries { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public SummaryModel Summary { get; set; }
    }
}

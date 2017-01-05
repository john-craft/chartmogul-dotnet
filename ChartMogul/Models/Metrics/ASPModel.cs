using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace ChartMogul.API.Models.Metrics
{
    public class ASPEntry
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "asp")]
        public int ASP { get; set; }
    }

    public class ASPModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<ASPEntry> Entries { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public SummaryModel Summary { get; set; }
    }
}

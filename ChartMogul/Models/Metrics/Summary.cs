using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Metrics
{
    public class Summary
    {
        [JsonProperty(PropertyName = "current")]
        public string Current { get; set; }

        [JsonProperty(PropertyName = "previous")]
        public string Previous { get; set; }

        [JsonProperty(PropertyName = "percentage-change")]
        public string PercentageChange { get; set; }
    }
}

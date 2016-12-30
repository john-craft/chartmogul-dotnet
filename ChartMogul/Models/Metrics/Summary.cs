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
        public int Current { get; set; }

        [JsonProperty(PropertyName = "previous")]
        public int Previous { get; set; }

        [JsonProperty(PropertyName = "percentage-change")]
        public decimal PercentageChange { get; set; }
    }
}

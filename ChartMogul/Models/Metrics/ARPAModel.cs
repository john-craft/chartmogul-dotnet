using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Metrics
{
    public class ARPAEntry
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "arpa")]
        public string Arpa { get; set; }
    }

    public class ARPAModel
    {
        public List<ARPAEntry> entries { get; set; }
        public Summary summary { get; set; }
    }
}

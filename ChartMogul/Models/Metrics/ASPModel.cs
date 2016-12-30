using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Metrics
{
    public class ASPEntry
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "asp")]
        public string ASP { get; set; }
    }

    public class ASPModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<ASPEntry> Entries { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public Summary Summary { get; set; }
    }
}

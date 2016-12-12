using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OConnors.ChartMogul.API
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Result { get; set; }

        [JsonProperty(PropertyName = "external_id")]
        public string ExternalId { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Enrichment
{
   public class AddCustomAttributeModel
    {
        [JsonProperty(PropertyName ="email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "custom")]
        public List<Custom> Custom { get; set; }
    }
    public class Custom
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set;}

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }

}

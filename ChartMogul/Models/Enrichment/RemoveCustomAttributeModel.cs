using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Enrichment
{
    public class RemoveCustomAttributeModel
    {
        [JsonProperty(PropertyName ="custom")]
        public string[] Custom { get; set; }
    }
}

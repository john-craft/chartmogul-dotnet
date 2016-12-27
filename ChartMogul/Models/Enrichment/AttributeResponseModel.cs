using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Enrichment
{
    public class AttributeResponseModel
    {
        [JsonProperty(PropertyName= "attributes")]
        public Attribute Attributes { get; set; }
    }
}

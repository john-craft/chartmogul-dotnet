using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OConnors.ChartMogul.API.Models
{
    public class DataSourceModel
    {
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}

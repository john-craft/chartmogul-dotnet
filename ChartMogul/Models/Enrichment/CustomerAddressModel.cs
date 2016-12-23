using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Enrichment
{
  public class CustomerAddressModel
    {
        [JsonProperty(PropertyName = "address_zip")]
        public CustomerAddressModel Zip { get; set; }

        [JsonProperty(PropertyName = "city")]
        public CustomerAddressModel City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public CustomerAddressModel State { get; set; }

        [JsonProperty(PropertyName = "country")]
        public CustomerAddressModel Country { get; set; }
    }
}

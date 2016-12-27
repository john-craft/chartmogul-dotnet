using Newtonsoft.Json;

namespace ChartMogul.API.Models.Enrichment
{
  public class CustomerAddressModel
    {
        [JsonProperty(PropertyName = "address_zip")]
        public string Zip { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    }
}

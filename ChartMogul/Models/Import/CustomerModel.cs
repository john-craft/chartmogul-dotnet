using Newtonsoft.Json;

namespace ChartMogul.API.Models.Import
{
    public class CustomerModel
    {
        [JsonProperty(PropertyName = "data_source_uuid")]
        public string Data_Source_Uuid { get; set; }

        [JsonProperty(PropertyName = "external_id")]
        public string External_Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }

        [JsonIgnore]
        public string Uuid { get; set; }
    }
}

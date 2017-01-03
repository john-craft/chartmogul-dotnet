using Newtonsoft.Json;

namespace ChartMogul.API.Models.Enrichment
{
    public class ClearbitModel
    {
        [JsonProperty(PropertyName = "person")]
        public Person Person { get; set; }

        [JsonProperty(PropertyName = "company")]
        public Company Company { get; set; }

    }

    public class Company
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "legalName")]
        public string LegalName { get; set; }
        [JsonProperty(PropertyName = "domain")]
        public string Domain { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "category")]
        public Category Category { get; set; }
        [JsonProperty(PropertyName = "metrics")]
        public Metrics Metrics { get; set; }
    }

    public class Metrics
    {
        [JsonProperty(PropertyName = "raised")]
        public string Raised { get; set; }

        [JsonProperty(PropertyName = "employees")]
        public string Employees { get; set; }

        [JsonProperty(PropertyName = "googleRank")]
        public string GoogleRank { get; set; }

        [JsonProperty(PropertyName = "alexaGlobalRank")]
        public string AlexaGlobalRank { get; set; }

        [JsonProperty(PropertyName = "marketCap")]
        public string MarketCap { get; set; }
    }

    public class Category
    {
        [JsonProperty(PropertyName = "sector")]
        public string Sector { get; set; }

        [JsonProperty(PropertyName = "industryGroup")]
        public string IndustryGroup { get; set; }

        [JsonProperty(PropertyName = "industry")]
        public string Industry { get; set; }

        [JsonProperty(PropertyName = "subIndustry")]
        public string SubIndustry { get; set; }
    }

    public class Person
    {
        [JsonProperty(PropertyName = "name")]
        public Name Name { get; set; }

        [JsonProperty(PropertyName = "employment")]
        public Employment Employment { get; set; }
    }

    public class Employment
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class Name
    {
        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; set; }
    }


}
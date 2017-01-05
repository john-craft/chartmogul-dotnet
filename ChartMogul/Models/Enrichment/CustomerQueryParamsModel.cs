

namespace ChartMogul.API.Models.Enrichment
{
    public class CustomerQueryParamsModel
    {
        public string DataSourceUUID { get; set; }
        public string Status { get; set; }
        public string System { get; set; }
        public string ExternalId { get; set; }
        public string Page { get; set; }
        public string PerPage { get; set; }
    }
}

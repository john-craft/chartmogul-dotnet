using Newtonsoft.Json;
using System.Collections.Generic;


namespace ChartMogul.API.Models.Import
{
    public class DataSourceResponseDataModel
    {
        [JsonProperty(PropertyName = "data_sources")]
        public List<DataSourceModel> DataSources { get; set; }
    }
}

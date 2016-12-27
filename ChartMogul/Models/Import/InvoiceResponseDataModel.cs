using Newtonsoft.Json;
using OConnors.ChartMogul.API.Models.Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Import
{
    class InvoiceResponseDataModel
    {
        [JsonProperty(PropertyName = "invoices")]
        public List<InvoiceModel> Invoices { get; set; }

        [JsonProperty(PropertyName = "current_page")]
        public int Current_Page { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int Total_Pages { get; set; }
    }
}

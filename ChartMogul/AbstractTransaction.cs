using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OConnors.ChartMogul.API
{
    public abstract class AbstractTransaction
    {
        protected readonly string _resourcePath = "/v1/import/invoices/:invoice_uuid/transactions";

        protected string Uuid { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public string ExternalId { get; set; }
        public string InvoiceUuid { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ChartMogul.API.Models.Import
{
    public class InvoiceModel
    {
        /// <summary>
        /// The ChartMogul UUID of the Customer that these invoices 
        /// belong to. Specified as part of the URL.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// A unique identifier specified by you for the invoice. Typically the 
        /// Invoice Number in your system. Accepts alphanumeric characters.
        /// </summary>
        [JsonProperty(PropertyName = "external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// The date on which this invoice was raised.
        /// </summary>
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// The 3-letter currency code of the currency in which this 
        /// invoice is being billed, e.g. USD, EUR, GBP.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The date within which this invoice must be paid.
        /// </summary>
        [JsonProperty(PropertyName = "due_date")]
        public string DueDate { get; set; }

        /// <summary>
        /// A list of Line Item objects.
        /// </summary>
        [JsonProperty(PropertyName = "line_items")]
        public List<LineItemModel> Items { get; set; }

        /// <summary>
        /// A list of Transaction objects.
        /// </summary>
        [JsonProperty(PropertyName = "transactions")]
        public List<TransactionModel> Transactions { get; set; }
    }
}

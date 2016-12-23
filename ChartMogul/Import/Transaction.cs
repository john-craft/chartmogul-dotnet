using ChartMogul.API.Models.Core;
using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Import
{
    public interface ITransaction
    {
        TransactionModel AddTransaction(InvoiceModel invoicemodel, TransactionModel transactionmodel, APIRequest apiRequest);
    }
    
    public class Transaction : ITransaction
    {
        private IHttp _iHttp;
        public Transaction(IHttp ihttp)
        {
            _iHttp = ihttp;
        }

        public TransactionModel AddTransaction(InvoiceModel invoicemodel, TransactionModel transactionmodel, APIRequest apiRequest)
        {
            apiRequest.RouteName = string.Format("import/invoices/{0}/transactions", invoicemodel.Uuid);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<TransactionModel, TransactionModel>(transactionmodel);
            return response;
        }
    }
}

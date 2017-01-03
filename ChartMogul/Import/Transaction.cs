using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Import;

namespace ChartMogul.API.Import
{
    public interface ITransaction
    {
        TransactionModel AddTransaction(InvoiceModel invoicemodel, TransactionModel transactionmodel, APIRequest apiRequest);
    }
    
    public class Transaction : ITransaction
    {
        private IHttp _iHttp;
        private const string url = "import/invoices/{0}/transactions";
        public Transaction(IHttp ihttp)
        {
            _iHttp = ihttp;
        }

        public TransactionModel AddTransaction(InvoiceModel invoicemodel, TransactionModel transactionmodel, APIRequest apiRequest)
        {
            apiRequest.RouteName = string.Format(url, invoicemodel.Uuid);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<TransactionModel, TransactionModel>(transactionmodel);
            return response;
        }
    }
}

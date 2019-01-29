using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Import;
using System.Collections.Generic;

namespace ChartMogul.API.Import
{
    public interface IInvoice
    {
        List<InvoiceModel> AddInvoice(CustomerModel customerModel, APIRequest apiRequest, InvoiceResponseDataModel invoiceModelList);
        List<InvoiceModel> GetInvoices(CustomerModel customerModel, APIRequest apirequest);
    }

    public class Invoice : IInvoice
    {
        private IHttp _iHttp;
        public Invoice(IHttp iHttp)
        {
            _iHttp = iHttp;
        }

        public List<InvoiceModel> AddInvoice(CustomerModel customerModel, APIRequest apiRequest, InvoiceResponseDataModel invoiceModelList)
        {
            apiRequest.RouteName = string.Format("import/customers/{0}/invoices", customerModel.Uuid);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<InvoiceResponseDataModel, InvoiceResponseDataModel>(invoiceModelList);
            return response.Invoices;
        }

        public List<InvoiceModel> GetInvoices(CustomerModel customerModel, APIRequest apirequest)
        {
            apirequest.RouteName = string.Format("import/customers/{0}/invoices", customerModel.Uuid);
            _iHttp.ApiRequest = apirequest;
            var response = _iHttp.Get<InvoiceResponseDataModel>();
            return response.Invoices;
        }
    }
}

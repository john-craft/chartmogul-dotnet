using ChartMogul.API.Models;
using ChartMogul.API.Models.Core;
using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Import
{
    public interface IInvoice
    {
        List<InvoiceModel> AddInvoice(CustomerModel customerModel, APIRequest apiRequest, List<InvoiceModel> invoiceModelList);
        List<InvoiceModel> GetInvoices(CustomerModel customerModel, APIRequest apirequest);
    }

    public class Invoice : IInvoice
    {
        private IHttp _iHttp;
        public Invoice(IHttp iHttp)
        {
            _iHttp = iHttp;
        }

        public List<InvoiceModel> AddInvoice(CustomerModel customerModel, APIRequest apiRequest, List<InvoiceModel> invoiceModelList)
        {
            apiRequest.RouteName = string.Format("import/customers/{0}/invoices", customerModel.Uuid);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<List<InvoiceModel>, InvoiceResponseDataModel>(invoiceModelList);
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

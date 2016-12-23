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
        InvoiceModel AddInvoice(CustomerModel customerModel, APIRequest apiRequest, InvoiceModel invoiceModel);
        List<InvoiceModel> GetInvoices(CustomerModel customerModel, APIRequest apirequest);
    }

    public class Invoice : IInvoice
    {
        private IHttp _iHttp;
        public Invoice(IHttp iHttp)
        {
            _iHttp = iHttp;
        }

        public InvoiceModel AddInvoice(CustomerModel customerModel, APIRequest apiRequest,InvoiceModel invoiceModel)
        {
            apiRequest.RouteName = string.Format("import/customers/{0}/invoices", customerModel.Uuid);
            _iHttp.ApiRequest = apiRequest;
            var listOfInvoices = new InvoiceResponseDataModel { Invoices = new List<InvoiceModel> { invoiceModel } };
            var response = _iHttp.Post<InvoiceResponseDataModel,InvoiceResponseDataModel>(listOfInvoices);
            return new InvoiceModel();
        }

        public List<InvoiceModel> GetInvoices(CustomerModel customerModel,APIRequest apirequest)
        {
            apirequest.RouteName = string.Format("import/customers/{0}/invoices", customerModel.Uuid);
            _iHttp.ApiRequest = apirequest;
            var response = _iHttp.Get<InvoiceResponseDataModel>();
            return response.Invoices;
        }
    }
}

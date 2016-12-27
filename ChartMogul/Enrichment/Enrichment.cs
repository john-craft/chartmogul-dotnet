using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Enrichment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Enrichment
{
    public interface IEnrichment
    {
        CustomerModel UpdateCustomer(CustomerPatchModel customerPatchModel, string customerUUID);
        CustomerModel GetCustomerDetails(string customerUUID);
        List<CustomerModel> GetAllCustomers();
        List<CustomerModel> SearchForCustomer(string email);
        void MergeCustomers(MergeCustomers mergeCustomers);
    }
    public class Enrichment: IEnrichment
    {
        public ICustomer _customer;
        public APIRequest ApiRequest { get; set; } 
        public Enrichment(ICustomer customer)
        {
            _customer = customer;       
        }

        public CustomerModel UpdateCustomer(CustomerPatchModel customerPatchModel, string customerUUID)
        {            
          return  _customer.UpdateCustomer(customerPatchModel, ApiRequest, customerUUID);
        }

        public CustomerModel GetCustomerDetails(string customerUUID)
        {
            return _customer.GetCustomerDetails(ApiRequest, customerUUID);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return _customer.GetAllCustomers(ApiRequest);
        }

        public List<CustomerModel> SearchForCustomer(string email)
        {
            return _customer.SearchForCustomer(ApiRequest, email);
        }

        public void MergeCustomers(MergeCustomers mergeCustomers)
        {
            _customer.MergeCustomers(ApiRequest, mergeCustomers);
        }

    }
}

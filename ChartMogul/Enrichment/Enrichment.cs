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
        CustomerTag GetCustomerAttribute(string customerUUID);
        string[] AddTagsToCustomer(string customerUUID, string[] tags);
        CustomerResponseModel AddTagsToCustomerWithEmail(string customerUUID, CustomerTag customerTag);
        CustomModel AddCustomAttribute(string customerUUID, AddCustomAttributeModel customAttributes);
        CustomerResponseModel AddCustomAttributeToCustomerWithEmail(string email, AddCustomAttributeModel customAttributes);
        CustomModel UpdateCustomAttributesOfCustomer(string customerUUID, CustomModel addCustomAttributeModel);
    }
    public class Enrichment: IEnrichment
    {
        public ICustomer _customer;
        public ICustomerAttribute _customerAttribute;
        public ITags _tags;
        public APIRequest ApiRequest { get; set; }
        public ICustomAttribute _customAttribute;
        public Enrichment(ICustomer customer, ICustomerAttribute customerAttribute, ITags tags, ICustomAttribute customAttribute)
        {
            _customer = customer;
            _customerAttribute = customerAttribute;
            _tags = tags;
            _customAttribute = customAttribute;
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

        public CustomerTag GetCustomerAttribute(string customerUUID)
        {
           return _customerAttribute.GetCustomerAttribute(customerUUID, ApiRequest);
        }

        public string[] AddTagsToCustomer(string customerUUID,string[] tags)
        {
            return _tags.AddTagsToCustomer(customerUUID,ApiRequest,tags);
        }

        public CustomerResponseModel AddTagsToCustomerWithEmail(string customerUUID, CustomerTag customerTag)
        {
            return _tags.AddTagsToCustomerWithEmail(customerUUID, ApiRequest, customerTag);
        }

        public string[] RemoveTagsFromCustomer(string customerUUID,string[] tagsToBeRemoved)
        {
            return _tags.RemoveTagsFromCustomer(customerUUID, ApiRequest, tagsToBeRemoved);
        }

        public CustomModel AddCustomAttribute(string customerUUID,AddCustomAttributeModel customAttributes)
        {
            return _customAttribute.AddCustomAttribute(customerUUID, ApiRequest, customAttributes);
        }

        public CustomerResponseModel AddCustomAttributeToCustomerWithEmail(string email, AddCustomAttributeModel customAttributes)
        {
            return _customAttribute.AddCustomAttributeToCustomerWithEmail(email, ApiRequest, customAttributes);
        }

        public CustomModel UpdateCustomAttributesOfCustomer(string customerUUID, CustomModel addCustomAttributeModel)
        {
            return _customAttribute.UpdateCustomAttributesOfCustomer(customerUUID, ApiRequest, addCustomAttributeModel);
        }
    }
}

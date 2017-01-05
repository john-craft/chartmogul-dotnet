using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Enrichment;
using System.Collections.Generic;

namespace ChartMogul.API.Enrichment
{
    public interface IEnrichment
    {
        CustomerModel UpdateCustomer(CustomerPatchModel customerPatchModel, string customerUUID);
        CustomerModel GetCustomerDetails(string customerUUID);
        List<CustomerModel> GetAllCustomers(CustomerQueryParamsModel queryParams);
        List<CustomerModel> SearchForCustomer(string email);
        void MergeCustomers(MergeCustomersModel mergeCustomers);
        CustomerTagModel GetCustomerAttribute(string customerUUID);
        string[] AddTagsToCustomer(string customerUUID, string[] tags);
        CustomerResponseModel AddTagsToCustomerWithEmail(string customerUUID, CustomerTagModel customerTag);
        CustomModel AddCustomAttribute(string customerUUID, AddCustomAttributeModel customAttributes);
        CustomerResponseModel AddCustomAttributeToCustomerWithEmail(AddCustomAttributeModel customAttributes);
        CustomModel UpdateCustomAttributesOfCustomer(string customerUUID, CustomModel addCustomAttributeModel);
    }

    public class Enrichment : IEnrichment
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
            return _customer.UpdateCustomer(customerPatchModel, ApiRequest, customerUUID);
        }

        public CustomerModel GetCustomerDetails(string customerUUID)
        {
            return _customer.GetCustomerDetails(ApiRequest, customerUUID);
        }

        public List<CustomerModel> GetAllCustomers(CustomerQueryParamsModel queryParams)
        {
            return _customer.GetAllCustomers(ApiRequest, queryParams);
        }

        public List<CustomerModel> SearchForCustomer(string email)
        {
            return _customer.SearchForCustomer(ApiRequest, email);
        }

        public void MergeCustomers(MergeCustomersModel mergeCustomers)
        {
            _customer.MergeCustomers(ApiRequest, mergeCustomers);
        }

        public CustomerTagModel GetCustomerAttribute(string customerUUID)
        {
            return _customerAttribute.GetCustomerAttribute(customerUUID, ApiRequest);
        }

        public string[] AddTagsToCustomer(string customerUUID, string[] tags)
        {
            return _tags.AddTagsToCustomer(customerUUID, ApiRequest, tags);
        }

        public CustomerResponseModel AddTagsToCustomerWithEmail(string customerUUID, CustomerTagModel customerTag)
        {
            return _tags.AddTagsToCustomerWithEmail(customerUUID, ApiRequest, customerTag);
        }

        public string[] RemoveTagsFromCustomer(string customerUUID, string[] tagsToBeRemoved)
        {
            return _tags.RemoveTagsFromCustomer(customerUUID, ApiRequest, tagsToBeRemoved);
        }

        public CustomModel AddCustomAttribute(string customerUUID, AddCustomAttributeModel customAttributes)
        {
            return _customAttribute.AddCustomAttribute(customerUUID, ApiRequest, customAttributes);
        }

        public CustomerResponseModel AddCustomAttributeToCustomerWithEmail(AddCustomAttributeModel customAttributes)
        {
            return _customAttribute.AddCustomAttributeToCustomerWithEmail(ApiRequest, customAttributes);
        }

        public CustomModel UpdateCustomAttributesOfCustomer(string customerUUID, CustomModel addCustomAttributeModel)
        {
            return _customAttribute.UpdateCustomAttributesOfCustomer(customerUUID, ApiRequest, addCustomAttributeModel);
        }

        public CustomModel RemoveCustomAttributeFromCustomer(string customerUUID, RemoveCustomAttributeModel removeCustomAttributeModel)
        {
            return _customAttribute.RemoveCustomAttributeFromCustomer(customerUUID, ApiRequest, removeCustomAttributeModel);
        }
    }
}

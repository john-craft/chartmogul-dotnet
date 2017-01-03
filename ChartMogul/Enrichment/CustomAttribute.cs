using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Enrichment;

namespace ChartMogul.API.Enrichment
{
    public interface ICustomAttribute
    {
        CustomModel AddCustomAttribute(string customerUUID, APIRequest apiRequest, AddCustomAttributeModel customModelToBeAdded);
        CustomerResponseModel AddCustomAttributeToCustomerWithEmail(APIRequest apiRequest, AddCustomAttributeModel customAttributes);
        CustomModel UpdateCustomAttributesOfCustomer(string customerUUID, APIRequest apiRequest, CustomModel addCustomAttributeModel);
        CustomModel RemoveCustomAttributeFromCustomer(string customerUUID, APIRequest apiRequest, RemoveCustomAttributeModel removeCustomAttributeModel);
    }

    public class CustomAttribute : ICustomAttribute
    {
        private IHttp _iHttp;
        private const string url = "customers{0}/attributes/custom";
        public CustomAttribute(IHttp iHttp)
        {
            _iHttp = iHttp;
        }

        public CustomModel AddCustomAttribute(string customerUUID, APIRequest apiRequest, AddCustomAttributeModel customModelToBeAdded)
        {
            apiRequest.RouteName = string.Format(url, string.Concat("/", customerUUID));
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<AddCustomAttributeModel, CustomModel>(customModelToBeAdded);
            return response;
        }

        public CustomerResponseModel AddCustomAttributeToCustomerWithEmail(APIRequest apiRequest, AddCustomAttributeModel customAttributes)
        {
            apiRequest.RouteName = string.Format(url, "");
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<AddCustomAttributeModel, CustomerResponseModel>(customAttributes);
            return response;
        }

        public CustomModel UpdateCustomAttributesOfCustomer(string customerUUID, APIRequest apiRequest, CustomModel addCustomAttributeModel)
        {
            apiRequest.RouteName = string.Format(url, string.Concat("/", customerUUID));
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Put<CustomModel, CustomModel>(addCustomAttributeModel);
            return response;
        }

        public CustomModel RemoveCustomAttributeFromCustomer(string customerUUID, APIRequest apiRequest, RemoveCustomAttributeModel removeCustomAttributeModel)
        {
            apiRequest.RouteName = string.Format(url, string.Concat("/", customerUUID));
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Delete<RemoveCustomAttributeModel, CustomModel>(removeCustomAttributeModel);
            return response;
        }
    }
}

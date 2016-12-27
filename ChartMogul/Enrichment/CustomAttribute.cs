using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Enrichment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Enrichment
{
    public interface ICustomAttribute
    {
        CustomModel AddCustomAttribute(string customerUUID, APIRequest apiRequest, AddCustomAttributeModel customModelToBeAdded);
        CustomerResponseModel AddCustomAttributeToCustomerWithEmail(string email, APIRequest apiRequest, AddCustomAttributeModel customAttributes);
        CustomModel UpdateCustomAttributesOfCustomer(string customerUUID, APIRequest apiRequest, AddCustomAttributeModel addCustomAttributeModel);
    }
    public class CustomAttribute: ICustomAttribute
    {
        private IHttp _iHttp;
        public CustomAttribute(IHttp iHttp)
        {
            _iHttp = iHttp;
        }

        public CustomModel AddCustomAttribute(string customerUUID, APIRequest apiRequest,AddCustomAttributeModel customModelToBeAdded)
        {
            apiRequest.RouteName = string.Concat("customers/", customerUUID, "/attributes/custom");
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<AddCustomAttributeModel,CustomModel>(customModelToBeAdded);
            return response;
        }

        public CustomerResponseModel AddCustomAttributeToCustomerWithEmail(string email, APIRequest apiRequest, AddCustomAttributeModel customAttributes)
        {
            apiRequest.RouteName = string.Concat("customers/attributes/custom");
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<AddCustomAttributeModel, CustomerResponseModel>(customAttributes);
            return response;
        }

        public CustomModel UpdateCustomAttributesOfCustomer(string customerUUID, APIRequest apiRequest, AddCustomAttributeModel addCustomAttributeModel)
        {
            apiRequest.RouteName = string.Concat("customers/",customerUUID,"/attributes/custom");
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Put<AddCustomAttributeModel, CustomModel>(addCustomAttributeModel);
            return response;
        }

    }
}

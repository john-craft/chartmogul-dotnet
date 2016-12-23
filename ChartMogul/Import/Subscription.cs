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
    public interface ISubscription
    {
        List<SubscriptionModel> GetSubscriptions(CustomerModel customermodel, APIRequest apiRequest);
        SubscriptionModel CancelSubscription(SubscriptionModel subscriptionmodel,APIRequest apirequest);
    }

    public class Subscription : ISubscription
    {
        private IHttp _ihttp;
        public Subscription(IHttp ihttp)
        {
            _ihttp = ihttp;
        }

        public SubscriptionModel CancelSubscription(SubscriptionModel subscriptionmodel, APIRequest apiRequest)
        {
            apiRequest.RouteName = string.Format("import/subscriptions/{0}", subscriptionmodel.Uuid);
            _ihttp.ApiRequest = apiRequest;
            var response = _ihttp.Put<SubscriptionModel, SubscriptionModel>(subscriptionmodel);
            return response;
        }

        public List<SubscriptionModel> GetSubscriptions(CustomerModel customermodel, APIRequest apiRequest)
        {
            apiRequest.RouteName = string.Format("import/customers/{0}/subscriptions", customermodel.Uuid);
            _ihttp.ApiRequest = apiRequest;
            var response = _ihttp.Get<SubscriptionResponseDataModel>();
            return response.Subscriptions;
        }
    }
}

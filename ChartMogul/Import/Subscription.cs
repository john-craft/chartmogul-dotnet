using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Import;
using System.Collections.Generic;

namespace ChartMogul.API.Import
{
    public interface ISubscription
    {
        List<SubscriptionModel> GetSubscriptions(CustomerModel customermodel, APIRequest apiRequest);
        SubscriptionModel CancelSubscription(SubscriptionModel subscriptionmodel, APIRequest apirequest);
    }

    public class Subscription : ISubscription
    {
        private IHttp _ihttp;
        private const string cancelSubscriptionUrl = "import/subscriptions/{0}";
        private const string getSubscriptionUrl = "import/customers/{0}/subscriptions";
        public Subscription(IHttp ihttp)
        {
            _ihttp = ihttp;
        }

        public SubscriptionModel CancelSubscription(SubscriptionModel subscriptionmodel, APIRequest apiRequest)
        {
            apiRequest.RouteName = string.Format(cancelSubscriptionUrl, subscriptionmodel.Uuid);
            _ihttp.ApiRequest = apiRequest;
            var response = _ihttp.Put<SubscriptionModel, SubscriptionModel>(subscriptionmodel);
            return response;
        }

        public List<SubscriptionModel> GetSubscriptions(CustomerModel customermodel, APIRequest apiRequest)
        {
            apiRequest.RouteName = string.Format(getSubscriptionUrl, customermodel.Uuid);
            _ihttp.ApiRequest = apiRequest;
            var response = _ihttp.Get<SubscriptionResponseDataModel>();
            return response.Subscriptions;
        }
    }
}

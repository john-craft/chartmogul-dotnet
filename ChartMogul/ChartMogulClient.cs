using System.Collections.Generic;
using StructureMap;
using ChartMogul.API.Models.Core;
using System.IO;

namespace ChartMogul.API
{
    /// <summary>
    /// Master client for interacting with ChartMogulClient services
    /// </summary>
   public class ChartMogulClient 
    {
        private APIRequest _apiRequest = new APIRequest();
        public Enrichment.Enrichment Enrichment{ get
            {
                var container = Container.For<MyRegistry>();
                var enrichmentObject = container.GetInstance<Enrichment.Enrichment>();
                enrichmentObject.ApiRequest = _apiRequest;
                return enrichmentObject;
            }    
        }

        public Import.Import Import {
            get
            {
                var container = Container.For<MyRegistry>();
                var importObject = container.GetInstance<Import.Import>();
                importObject.ApiRequest = _apiRequest;
                return importObject;
            }
        }

        public Metrics.Metrics Metrics
        {
            get
            {
                var container = Container.For<MyRegistry>();
                var metricsObject = container.GetInstance<Metrics.Metrics>();
                metricsObject.ApiRequest = _apiRequest;
                return metricsObject;
            }
        }


        public ChartMogulClient(string accountKey, string secretKey)
        {
            if (string.IsNullOrEmpty(accountKey))
            {
                throw new InvalidDataException("AccountToken cannot be null");
            }

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidDataException("SecretKey cannot be null");
            }
            Configuration config = new Configuration(accountKey, secretKey);
      //      configureDependencies();
        }



        /// <summary>
        /// The Headers provided by the client to add to the service
        /// </summary>
        public void AddHeaders(Dictionary<string, string> dictHeaders)
        {
            foreach (KeyValuePair<string, string> entry in dictHeaders)
            {
                _apiRequest.SetHeader(entry.Key, entry.Value);
            }
        }

    }
}   

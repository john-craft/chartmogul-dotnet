using ChartMogul.API.Import;
using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using StructureMap;
using ChartMogul.API.Models.Core;
using System.Text;
using System.IO;
using ChartMogul.API.Enrichment;
namespace ChartMogul.API
{
    /// <summary>
    /// Master client for interacting with ChartMogulClient services
    /// </summary>
   public class ChartMogulClient 
    {
        private Import.ICustomer _iCustomer;
        private IDataSource _iDataSource;
        private IPlan _iPlan;
        private IInvoice _iInvoice;
        private ITransaction _iTransaction;
        private ISubscription _iSubscription;
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


        public ChartMogulClient(Import.ICustomer iCustomer, IDataSource iDataSource, IPlan iPlan, IInvoice iInvoice, ITransaction iTransaction, ISubscription iSubscription)
        {
            _iCustomer = iCustomer;
            _iDataSource = iDataSource;
            _iPlan = iPlan;
            _iInvoice = iInvoice;
            _iTransaction = iTransaction;
            _iSubscription = iSubscription;
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


using System;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using ChartMogul.API.Models;
using System.Net.Http;
using System.Web;
using ChartMogul.API.Enums;
using ChartMogul.API.Exceptions;
using System.Net.Http;
using System.Web;
using OConnors.ChartMogul.API.Models;
using System.Collections.Generic;

namespace ChartMogul.API
{
    public class Http
    {
        /// <summary>
        /// Connection timeout in milliseconds
        /// </summary>
        private const int ConnectionTimeout = 10000;

        /// <summary>
        /// JSON header value
        /// </summary>
        private const string ApplicationJson = "application/json";

        /// <summary>
        /// Service key
        /// </summary>
        private readonly string _serviceKey;

        /// <summary>
        /// Authenticated
        /// </summary>
        private readonly bool _authenticated;

        /// <summary>
        /// Constructor
        /// </summary>
        public Http()
        {
            _authenticated = true;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceKey">The authorization key for the service</param>
        public Http(string serviceKey)
        {
            _serviceKey = serviceKey;
            _authenticated = true;
        }

        /// <summary>
        /// Perform a GET request
        /// </summary>
        internal TO Get<TO>(string api)
        {
            HttpWebRequest request = CreateRequest(api, RequestMethod.Get, null, _authenticated);
            return SendRequest<TO>(request);
        }

        /// <summary>
        /// Perform a POST request
        /// </summary>
        internal void Post(string api, object item)
        {
            HttpWebRequest request = CreateRequest(api, RequestMethod.Post, item, _authenticated);
            SendRequest(request);
        }

        /// <summary>
        /// Perform a PUT request
        /// </summary>
        internal void Put(string api, object item)
        {
            HttpWebRequest request = CreateRequest(api, RequestMethod.Put, item, _authenticated);
            SendRequest(request);
        }

        /// <summary>
        /// Perform a POST request
        /// </summary>
        internal TO Post<TI, TO>(string api, TI item)
        {
            HttpWebRequest request = CreateRequest(api, RequestMethod.Post, item, _authenticated);
            return SendRequest<TO>(request);
        }

        /// <summary>
        /// Perform a POST request
        /// </summary>
        internal TO Put<TI, TO>(string api, TI item)
        {
            HttpWebRequest request = CreateRequest(api, RequestMethod.Put, item, _authenticated);
            return SendRequest<TO>(request);
        }


        /// <summary>
        /// Perform a DELETE request
        /// </summary>
        public void Delete(string api)
        {
            HttpWebRequest request = CreateRequest(api, RequestMethod.Delete, null, _authenticated);
            SendRequest(request);
        }

        /// <summary>
        /// Handle an incoming request
        /// </summary>
        /// <typeparam name="TO"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public TO HandleRequest<TO>(HttpRequest request)
        {
            if (request.HttpMethod != "POST")
            {
               new ChartMogulException("Invalid request");
            }

            return HandleResponse<TO>(request.InputStream);
        }

        #region helpers

        private HttpWebRequest CreateRequest(string api, RequestMethod method, object data, bool authorize)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(api);
            //request.Accept = ApplicationJson;
            request.Accept= "*/*";
            request.Timeout = ConnectionTimeout;

            switch (method)
            {
                case RequestMethod.Get:
                    request.Method = WebRequestMethods.Http.Get;
                    break;
                case RequestMethod.Post:
                    request.Method = WebRequestMethods.Http.Post;
                    break;
                case RequestMethod.Put:
                    request.Method = WebRequestMethods.Http.Put;
                    break;
                case RequestMethod.Delete:
                    request.Method = "DELETE";
                    break;
                default:
                    throw new NotSupportedException(String.Format("Request method {0} not supported", method.ToString()));
            }

            if (authorize)
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(Configuration.AccountToken + ":" + Configuration.SecretKey);
                var credentials = Convert.ToBase64String(plainTextBytes);
                request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + credentials);
            }

            try
            {
                if (data != null)
                {
                    request.ContentType = ApplicationJson;
                    string serializedData = JsonConvert.SerializeObject(data);
                    byte[] bytes = Encoding.ASCII.GetBytes(serializedData);
                    request.ContentLength = bytes.Length;

                    using (Stream outputStream = request.GetRequestStream())
                    {
                        outputStream.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            catch (WebException exc)
            {
                throw new WebException("Error with request " + request.RequestUri, exc);
            }

            return request;
        }

        private void SendRequest(HttpWebRequest request)
        {
            try
            {
                using (var response = request.GetResponse())
                {
                    // NO action to take
                }
            }
            catch (WebException exc)
            {
                HandleError(exc);
            }
        }

        private T SendRequest<T>(HttpWebRequest request)
        {
            try
            {
                using (var response = request.GetResponse())
                {
                    var test = response.GetResponseStream();
                    return HandleResponse<T>(response.GetResponseStream());
                }
            }
            catch (WebException exc)
            {
                HandleError(exc);
                return default(T);
            }
        }

        private T HandleResponse<T>(Stream responseStream)
        {   
            using (var reader = new StreamReader(responseStream))
            {               
                var responseText = reader.ReadToEnd();             
                return JsonConvert.DeserializeObject<T>(responseText);         
            }
        }

        private void HandleError(WebException exc)
        {
            using (var reader = new StreamReader(exc.Response.GetResponseStream()))
            {
                string content = string.Empty;
                try
                {
                     content = reader.ReadToEnd();
                }
                catch (Exception)
                {
                    throw exc;
                }
                new ChartMogulException(content);
            }
        }

        #endregion
    }
}

﻿using System;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Web;
using ChartMogul.API.Enums;
using ChartMogul.API.Exceptions;
using System.Collections.Generic;
using ChartMogul.API.Models.Core;

namespace ChartMogul.API
{
    public interface IHttp
    {
        TO Get<TO>();
        void Post(object item);
        void Put(object item);
        TO Post<TI, TO>(TI item);
        TO Put<TI, TO>(TI item);
        APIRequest ApiRequest { get; set; }
        void Delete();
        TO Patch<TI, TO>(TI item);
        TO Delete<TI, TO>(TI item);

    }
    public class Http : IHttp
    {
        private readonly IGetResponse _getResponse;
        public Http(IGetResponse getResponse)
        {
            _getResponse = getResponse;
        }
        /// <summary>
        /// Connection timeout in milliseconds
        /// </summary>
        private const int connectionTimeout = 10000;
        private const string baseUrl = "https://api.chartmogul.com/v1/";
        /// <summary>
        /// JSON header value
        /// </summary>
        private const string applicationJson = "application/json";

        /// <summary>
        /// Authenticated
        /// </summary>
        private readonly bool _authenticated = true;

        public APIRequest ApiRequest { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public Http()
        {
            _authenticated = true;
        }

        /// <summary>
        /// Perform a GET request
        /// </summary>
        public TO Get<TO>()
        {
            HttpWebRequest request = CreateRequest(RequestMethod.Get, null, _authenticated);
            return SendRequest<TO>(request);
        }

        /// <summary>
        /// Perform a POST request
        /// </summary>
        public void Post(object item)
        {
            HttpWebRequest request = CreateRequest(RequestMethod.Post, item, _authenticated);
            SendRequest(request);
        }

        /// <summary>
        /// Perform a PUT request
        /// </summary>
        public void Put(object item)
        {
            HttpWebRequest request = CreateRequest(RequestMethod.Put, item, _authenticated);
            SendRequest(request);
        }

        /// <summary>
        /// Perform a POST request
        /// </summary>
        public TO Post<TI, TO>(TI item)
        {
            HttpWebRequest request = CreateRequest(RequestMethod.Post, item, _authenticated);
            return SendRequest<TO>(request);
        }


        /// <summary>
        /// Perform a POST request
        /// </summary>
        public TO Put<TI, TO>(TI item)
        {
            HttpWebRequest request = CreateRequest(RequestMethod.Put, item, _authenticated);
            return SendRequest<TO>(request);
        }


        /// <summary>
        /// Perform a DELETE request
        /// </summary>
        public void Delete()
        {
            HttpWebRequest request = CreateRequest(RequestMethod.Delete, null, _authenticated);
            SendRequest(request);
        }

        public TO Patch<TI, TO>(TI item)
        {
            HttpWebRequest request = CreateRequest(RequestMethod.Patch, item, _authenticated);
            return SendRequest<TO>(request);
        }

        public TO Delete<TI,TO>(TI item)
        {
            HttpWebRequest request = CreateRequest(RequestMethod.Delete, item, _authenticated);
            return SendRequest<TO>(request);
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

    

        private HttpWebRequest CreateRequest(RequestMethod method, object data, bool authorize)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(string.Concat(baseUrl, ApiRequest.RouteName));
            request.Accept = "*/*";
            request.Timeout = connectionTimeout;
            SetRequestMethod(request,  method);
            
            if (authorize)
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(Configuration.AccountToken + ":" + Configuration.SecretKey);
                var credentials = Convert.ToBase64String(plainTextBytes);
                request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + credentials);
            }

            foreach (KeyValuePair<string, string> entry in ApiRequest.Header)
            {
                request.Headers.Add(entry.Key, entry.Value);
            }

            try
            {
                if (data != null)
                {
                    request.ContentType = applicationJson;
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

        private void SetRequestMethod(HttpWebRequest request, RequestMethod method)
        {
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
                case RequestMethod.Patch:
                    request.Method = "PATCH";
                    break;
                default:
                    throw new NotSupportedException(String.Format("Request method {0} not supported", method.ToString()));
            }
        }

        private void SendRequest(HttpWebRequest request)
        {
            try
            {
                using (var response =_getResponse.GetResponseFromServer(request))
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
                using (var response = _getResponse.GetResponseFromServer(request))
                {                 
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
            HttpWebResponse errorResponse = exc.Response as HttpWebResponse;
            {
                string error = string.Empty;
                using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                {
                    try
                    {
                        error = reader.ReadToEnd();
                    }
                    catch (Exception)
                    {
                        throw exc;
                    }
                }
                GenerateErrorResponse(errorResponse.StatusCode, error);
            }
        }

        private void GenerateErrorResponse(HttpStatusCode statusCode, string errorDetails)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest: throw new SchemaInvalidException(errorDetails);
                case HttpStatusCode.Forbidden: throw new ForbiddenException(errorDetails);
                case HttpStatusCode.NotFound: throw new NotFoundException(errorDetails);
                case HttpStatusCode.Unauthorized: throw new UnAuthorizedUserException(errorDetails);
                case HttpStatusCode.PaymentRequired: throw new RequestFailedException(errorDetails);
                case (HttpStatusCode)422: throw new SchemaInvalidException(errorDetails);
                default:
                    throw new ChartMogulException(errorDetails);
            }
        }
     
    }
}

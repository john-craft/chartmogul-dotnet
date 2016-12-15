using ChartMogul.API.Exceptions;
using ChartMogul.API.Models.Core;
using OConnors.ChartMogul.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Common
{

    public interface IChartMogulCore
    {
        void SetConfiguration(Models.Core.Config config);
        ApiResponse CallApi(APIRequest ApiRequest);
       // APIRequest ApiRequest { get; set; }
    }

    public class ChartMogulCore : IChartMogulCore
    {
        private readonly string _baseUrl = "https://api.chartmogul.com/v1/";
        private string _credentials;
       // public APIRequest ApiRequest { get; set; }
      
        public void SetConfiguration(Models.Core.Config config)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(config.AccountToken + ":" + config.SecretKey);
            _credentials = Convert.ToBase64String(plainTextBytes);
        }


        public ApiResponse CallApi(APIRequest ApiRequest)
        {
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(Path.Combine(_baseUrl, ApiRequest.URLPath));
                //httpRequest.Headers.Add("Authorization", "Basic " + _credentials);
                foreach (KeyValuePair<string, string> entry in ApiRequest.Header)
                {
                    httpRequest.Headers.Add(entry.Key, entry.Value);
                }

                httpRequest.Accept = "*/*";
                httpRequest.Method = ApiRequest.HttpMethod.ToUpper();

                if (ApiRequest.HttpMethod == "POST")
                {
                    httpRequest.ContentType = "application/json";
                }

                // Only write the json file when it is a add call or a update call
                if (!string.IsNullOrEmpty(ApiRequest.JsonData))
                {
                    using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                    {
                        streamWriter.Write(ApiRequest.JsonData);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }          
                WebResponse response = (HttpWebResponse)httpRequest.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                {
                    var responseText = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    return new ApiResponse { Success = true, Json = responseText };
                }
            }
            catch (WebException ex)
            {                          
                if (ex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)ex.Response)
                    {
                        string error = string.Empty;
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                             error = reader.ReadToEnd();
                        }
                        GenerateErrorResponse(errorResponse.StatusCode, error);
                    }
                }         
              return new ApiResponse { Success = false, Message = "Could not add customer: " + ex.Message };
            }
        }


        public void GenerateErrorResponse(HttpStatusCode statusCode,string errorDetails)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest: new SchemaInvalidException(errorDetails); break;
                case HttpStatusCode.Forbidden: new ForbiddenException(errorDetails); break;
                case HttpStatusCode.NotFound: new NotFoundException(errorDetails); break;
                case HttpStatusCode.Unauthorized: new UnAuthorizedUserException(errorDetails); break;
                case HttpStatusCode.PaymentRequired: new RequestFailedException(errorDetails);break;
                default:
                    new ChartMogulException(errorDetails); break;
            }
        }



    }
}

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
        ApiResponse CallApi(APIRequest apiRequest);

    }

   public class ChartMogulCore: IChartMogulCore
    {
        private readonly string _baseUrl = "https://api.chartmogul.com/v1/";
        private string _credentials;

        public void SetConfiguration(Models.Core.Config config)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(config.AccountToken + ":" + config.SecretKey);
            _credentials = Convert.ToBase64String(plainTextBytes);
        }

        public ApiResponse CallApi(APIRequest apiRequest)
        {
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(_baseUrl + apiRequest.URLPath);
                //httpRequest.Headers.Add("Authorization", "Basic " + _credentials);
                foreach (KeyValuePair<string, string> entry in apiRequest.Header)
                {
                   httpRequest.Headers.Add(entry.Key, entry.Value);
                }


                httpRequest.Accept = "*/*";
                httpRequest.Method = apiRequest.HttpMethod.ToUpper();

                if (apiRequest.HttpMethod == "POST")
                {
                    httpRequest.ContentType = "application/json";
                }

                // Only write the json file when it is a add call or a update call
                if (!string.IsNullOrEmpty(apiRequest.JsonData))
                {
                    using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                    {
                        streamWriter.Write(apiRequest.JsonData);
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
            catch (Exception ex)
            {
                return new ApiResponse { Success = false, Message = "Could not add customer: " + ex.Message };
            }
        }



    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OConnors.ChartMogul
{
    public class Client
    {
        private readonly string _baseUrl = "https://api.chartmogul.com/v1/";
        private readonly string _credentials;
        private DataSource _ds;

        public Client(Config config)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(config.AccountToken + ":" + config.SecretKey);
            _credentials = Convert.ToBase64String(plainTextBytes);
        }

        public List<DataSource> GetDataSources()
        {
            string urlPath = "import/data_sources";
            ApiResponse resp = CallApi(urlPath, "GET");
            if (resp.Success)
            {
                IEnumerable<DataSource> dataSources = JsonConvert.DeserializeObject<IEnumerable<DataSource>>(resp.Json);
                return dataSources.ToList();
            }
            else
                return null;
        }

        public string AddDataSource(DataSource dataSource)
        {
            throw new NotImplementedException();
        }

        public string DeleteDataSource()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            string urlPath = "import/customers";
            ApiResponse resp = CallApi(urlPath, "GET");
            if (resp.Success)
            {
                IEnumerable<Customer> customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(resp.Json);
                return customers.ToList();
            }
            else
                return null;
        }

        public bool AddCustomer(Customer cust)
        {
            if (cust == null)
                return false;

            string urlPath = "import/customers";
            cust.DataSource = _ds.Uuid;
            string json = JsonConvert.SerializeObject(cust);

            ApiResponse resp = CallApi(urlPath, "POST", json);
            if (resp.Success)
                return true;
            else
                return false;
        }

        public void DeleteCustomer(Customer cust)
        {
            throw new NotImplementedException();
        }

        public List<Plan> GetPlans()
        {
            string urlPath = "import/plans";
            ApiResponse resp = CallApi(urlPath, "GET");
            if (resp.Success)
            {
                IEnumerable<Plan> plans = JsonConvert.DeserializeObject<IEnumerable<Plan>>(resp.Json);
                return plans.ToList();
            }
            else
                return null;
        }

        public bool AddPlan(Plan plan)
        {
            string urlPath = "import/plans";
            plan.DataSource = _ds.Uuid;
            string json = JsonConvert.SerializeObject(plan);

            ApiResponse resp = CallApi(urlPath, "POST", json);
            if (resp.Success)
                return true;
            else
                return false;
        }

        public List<Invoice> GetInvoices()
        {
            throw new NotImplementedException();
        }

        public bool AddInvoice(List<Invoice> invoices, Customer customer)
        {
            string urlPath = "import/customers/" + customer.Uuid + "/invoices";
            string json = JsonConvert.SerializeObject(invoices);

            ApiResponse resp = CallApi(urlPath, "POST", json);
            if (resp.Success)
                return true;
            else
                return false;
        }

        public List<Subscription> GetSubscriptions(Customer cust)
        {
            string urlPath = "import/customers/" + cust.Uuid + "/subscriptions";
            ApiResponse resp = CallApi(urlPath, "GET");
            if (resp.Success)
            {
                IEnumerable<Subscription> subscriptions = JsonConvert.DeserializeObject<IEnumerable<Subscription>>(resp.Json);
                return subscriptions.ToList();
            }
            else
                return null;
        }

        public bool CancelSubscription(Subscription sub, DateTime cancelledAt)
        {
            string urlPath = "import/subscriptions/" + sub.Uuid;
            sub.CancellationDates = cancelledAt;
            string json = JsonConvert.SerializeObject(sub);

            ApiResponse resp = CallApi(urlPath, "PATCH", json);
            if (resp.Success)
                return true;
            else
                return false;
        }

        private ApiResponse CallApi(string urlPath, string httpMethod, string jsonToWrite = "")
        {
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(_baseUrl + urlPath);
                httpRequest.Headers.Add("Authorization", "Basic " + _credentials);
                httpRequest.Accept = "*/*";
                httpRequest.Method = httpMethod.ToUpper();

                if (httpMethod == "POST")
                {
                    httpRequest.ContentType = "application/json";
                }

                // Only write the json file when it is a add call or a update call
                if (!string.IsNullOrEmpty(jsonToWrite))
                {
                    using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                    {
                        streamWriter.Write(jsonToWrite);
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

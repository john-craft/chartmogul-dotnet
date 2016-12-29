using ChartMogul.API;
using ChartMogul.API.Import;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace TestChartMogul.Import
{
    [TestClass]
    public class ParentTest
    {

        public Mock<IDataSource> _dataSource;     
        public Mock<IGetResponse> _getResponse;

        public ParentTest()
        {
            _dataSource = new Mock<IDataSource>();         
        }

        public void MockHttpErrorResponse(HttpStatusCode statusCode, string message)
        {
            var httpWebResponse = new Mock<HttpWebResponse>();
            string serializedData = JsonConvert.SerializeObject(message);
            var expectedBytes = Encoding.UTF8.GetBytes(serializedData);
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);
            httpWebResponse.Setup(x => x.StatusCode).Returns(statusCode);
            httpWebResponse.Setup(x => x.ContentLength).Returns(-1);
            httpWebResponse.Setup(x => x.ContentType).Returns("text/html;charset=utf-8");
            httpWebResponse.Setup(x => x.GetResponseStream()).Returns(responseStream);
            var request = new Mock<WebResponse>();
            var response = new Mock<HttpWebRequest>();
            request.Setup(c => c.GetResponseStream()).Throws(new WebException(message, new Exception(), (WebExceptionStatus)400, httpWebResponse.Object));
            response.Setup(c => c.GetResponse()).Returns(request.Object);
            _getResponse.Setup(x => x.GetResponseFromServer(It.IsAny<HttpWebRequest>())).Throws(new WebException(message, new Exception(), (WebExceptionStatus)400, httpWebResponse.Object));
        }

        public void MockHttpResponse<T>(T data)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            var expectedBytes = Encoding.UTF8.GetBytes(serializedData);
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);
            var request = new Mock<WebResponse>();
            var response = new Mock<HttpWebRequest>();
            request.Setup(c => c.GetResponseStream()).Returns(responseStream);
            response.Setup(c => c.GetResponse()).Returns(request.Object);
            _getResponse.Setup(x => x.GetResponseFromServer(It.IsAny<HttpWebRequest>())).Returns(request.Object);
        }
    }
}

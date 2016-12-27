using ChartMogul.API.Models;
using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Import;
using OConnors.ChartMogul.API.Models;
using OConnors.ChartMogul.API.Models.Import;
using System;
using System.Collections.Generic;

namespace ChartMogul.API.Import
{

    public interface IDataSource
    {
        List<DataSourceModel> GetDataSources(APIRequest apiRequest);
        DataSourceModel AddDataSource(DataSourceModel datasourcemodal, APIRequest apiRequest);
        void DeleteDataSource(DataSourceModel dataSourcemodel, APIRequest apiRequest);
    }

    public class DataSource : IDataSource
    {
        private IHttp _iHttp;
        public DataSource(IHttp iHttp)
        {
            _iHttp = iHttp;
        }
        public List<DataSourceModel> GetDataSources(APIRequest apiRequest)
        {
            apiRequest.RouteName = "import/data_sources";
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Get<DataSourceResponseDataModel>();
            return response.DataSources;
        }

        public DataSourceModel AddDataSource(DataSourceModel dataSourceModel, APIRequest apiRequest)
        {
            apiRequest.RouteName = "import/data_sources";
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<DataSourceModel, DataSourceModel>(dataSourceModel);
            return response;
        }

        public void DeleteDataSource(DataSourceModel dataSourcemodel, APIRequest apiRequest)
        {
            apiRequest.RouteName = "import/data_sources/" + dataSourcemodel.Uuid;
            _iHttp.ApiRequest = apiRequest;
            _iHttp.Delete();

        }
    }
}

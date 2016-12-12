using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Import
{

    public interface IDataSource
    {
        List<DataSourceModel> GetDataSources();
        DataSourceModel AddDataSource(DataSourceModel dataSource);
        void DeleteDataSource();
    }

  public class DataSource:IDataSource
    {
        public List<DataSourceModel> GetDataSources()
        {
            throw new NotImplementedException();
        }


        public DataSourceModel AddDataSource(DataSourceModel dataSource)
        {
            throw new NotImplementedException();
        }


        public void DeleteDataSource()
        {
            throw new NotImplementedException();
        }

    }
}

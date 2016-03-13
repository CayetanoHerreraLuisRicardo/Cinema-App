using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class ELSEPTIMOARTEDataSource : DataSourceBase<RssSchema>
    {
        private const string _url =@"http://www.elseptimoarte.net/rss.php";

        protected override string CacheKey
        {
            get { return "ELSEPTIMOARTEDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<RssSchema>> LoadDataAsync()
        {
            try
            {
                var rssDataProvider = new RssDataProvider(_url);
                return await rssDataProvider.Load();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("ELSEPTIMOARTEDataSourceDataSource.LoadData", ex.ToString());
                return new RssSchema[0];
            }
        }
    }
}

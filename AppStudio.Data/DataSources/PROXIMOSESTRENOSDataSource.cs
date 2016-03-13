using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class PROXIMOSESTRENOSDataSource : DataSourceBase<RssSchema>
    {
        private const string _url =@"http://rss.sensacine.com/cine/proximamente";

        protected override string CacheKey
        {
            get { return "PROXIMOSESTRENOSDataSource"; }
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
                AppLogs.WriteError("PROXIMOSESTRENOSDataSourceDataSource.LoadData", ex.ToString());
                return new RssSchema[0];
            }
        }
    }
}

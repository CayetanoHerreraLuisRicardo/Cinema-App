using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class CORTOMETRAJESDataSource : DataSourceBase<RssSchema>
    {
        private const string _url =@"http://www.elmulticine.com/rss_cortos.php";

        protected override string CacheKey
        {
            get { return "CORTOMETRAJESDataSource"; }
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
                AppLogs.WriteError("CORTOMETRAJESDataSourceDataSource.LoadData", ex.ToString());
                return new RssSchema[0];
            }
        }
    }
}

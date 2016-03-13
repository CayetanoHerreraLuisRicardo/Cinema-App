using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class NOTICIASDESERIESDataSource : DataSourceBase<RssSchema>
    {
        private const string _url =@"http://rss.sensacine.com/actualidad/tv";

        protected override string CacheKey
        {
            get { return "NOTICIASDESERIESDataSource"; }
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
                AppLogs.WriteError("NOTICIASDESERIESDataSourceDataSource.LoadData", ex.ToString());
                return new RssSchema[0];
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class TOPCRITICASPRENSADataSource : DataSourceBase<RssSchema>
    {
        private const string _url =@"http://rss.sensacine.com/cine/prensa";

        protected override string CacheKey
        {
            get { return "TOPCRITICASPRENSADataSource"; }
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
                AppLogs.WriteError("TOPCRITICASPRENSADataSourceDataSource.LoadData", ex.ToString());
                return new RssSchema[0];
            }
        }
    }
}

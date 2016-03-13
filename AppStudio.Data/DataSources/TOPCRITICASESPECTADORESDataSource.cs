using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class TOPCRITICASESPECTADORESDataSource : DataSourceBase<RssSchema>
    {
        private const string _url =@"http://rss.sensacine.com/cine/espectadores";

        protected override string CacheKey
        {
            get { return "TOPCRITICASESPECTADORESDataSource"; }
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
                AppLogs.WriteError("TOPCRITICASESPECTADORESDataSourceDataSource.LoadData", ex.ToString());
                return new RssSchema[0];
            }
        }
    }
}

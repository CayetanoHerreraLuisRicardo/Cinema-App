using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class PELICULASENCARTELERADataSource : DataSourceBase<RssSchema>
    {
        private const string _url =@"http://rss.sensacine.com/cine/encartelera";

        protected override string CacheKey
        {
            get { return "PELICULASENCARTELERADataSource"; }
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
                AppLogs.WriteError("PELICULASENCARTELERADataSourceDataSource.LoadData", ex.ToString());
                return new RssSchema[0];
            }
        }
    }
}

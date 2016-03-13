using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class LaButacaDataSource : DataSourceBase<RssSchema>
    {
        private const string _url =@"http://pipes.yahoo.com/pipes/pipe.run?_id=d3a59d5348ad69566fa24f781376ec19&_render=rss";

        protected override string CacheKey
        {
            get { return "LaButacaDataSource"; }
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
                AppLogs.WriteError("LaButacaDataSourceDataSource.LoadData", ex.ToString());
                return new RssSchema[0];
            }
        }
    }
}

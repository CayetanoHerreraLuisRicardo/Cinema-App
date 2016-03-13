using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class CONTACTODataSource : DataSourceBase<CONTACTOSchema>
    {
        private const string _file = "/Assets/Data/CONTACTODataSource.json";

        protected override string CacheKey
        {
            get { return "CONTACTODataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<CONTACTOSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<CONTACTOSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("CONTACTODataSource.LoadData", ex.ToString());
                return new CONTACTOSchema[0];
            }
        }
    }
}

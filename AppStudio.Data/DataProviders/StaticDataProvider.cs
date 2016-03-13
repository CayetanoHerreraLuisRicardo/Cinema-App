using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Windows.Storage;
using Windows.Storage.Streams;

namespace AppStudio.Data
{
    public class StaticDataProvider
    {
        private Uri _uri;

        public StaticDataProvider(string filePath)
        {
            string url = String.Format("ms-appx://{0}", filePath);
            _uri = new Uri(url);
        }

        public async Task<IEnumerable<T>> Load<T>()
        {
            try
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(_uri);
                IRandomAccessStreamWithContentType randomStream = await file.OpenReadAsync();

                using (StreamReader r = new StreamReader(randomStream.AsStreamForRead()))
                {
                    string data = await r.ReadToEndAsync();
                    IEnumerable<T> records = JsonConvert.DeserializeObject<ItemsHelper<T>>(data).Items;
                    return records;
                }
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("ServiceDataProvider.Load", ex);
                return null;
            }
        }
    }

    public class ItemsHelper<T>
    {
        public IEnumerable<T> Items { get; set; }
    }
}

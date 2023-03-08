using Newtonsoft.Json;
using RepoStrategy.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoStrategy.Strategy
{
    public class LocalDataRetrievalStrategy<T> : IDataRetrievalStrategy<T>
    {
        private readonly string LocalFilePath;

        public LocalDataRetrievalStrategy(string filePath)
        {
            LocalFilePath = filePath;
        }

        public async Task<IEnumerable<T>> RetrieveData()
        {
            IEnumerable<T> data = await Task.Run(() =>
            {
                string fileContents = File.ReadAllText(LocalFilePath);
                IEnumerable<T> deserializedData = JsonConvert.DeserializeObject<IEnumerable<T>>(fileContents, Converter.Settings);
                return deserializedData ?? Enumerable.Empty<T>();
            });

            return data;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RepoStrategy.Strategy.Factory
{
    public class DataRetrievalStrategyFactory : IDataRetrievalStrategyFactory
    {
        public IDataRetrievalStrategy<T> CreateApiDataRetrievalStrategy<T>(string url)
        {
            return new ApiDataRetrievalStrategy<T>(new HttpClient(), url);
        }

        public IDataRetrievalStrategy<T> CreateLocalDataRetrievalStrategy<T>(string path)
        {
            return new LocalDataRetrievalStrategy<T>(path);
        }
    }
}

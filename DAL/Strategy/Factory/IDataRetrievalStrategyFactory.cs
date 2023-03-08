using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoStrategy.Strategy.Factory
{
    public interface IDataRetrievalStrategyFactory
    {
        IDataRetrievalStrategy<T> CreateApiDataRetrievalStrategy<T>(string url);
        IDataRetrievalStrategy<T> CreateLocalDataRetrievalStrategy<T>(string path);
    }
}

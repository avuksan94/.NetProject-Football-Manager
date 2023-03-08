using Newtonsoft.Json;
using RepoStrategy.Strategy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoStrategy.Repo
{
    public class DataRepo<T> : IRepo<T>
    {
        private readonly IDataRetrievalStrategy<T> DataRetrievalStrategy;

        public DataRepo(IDataRetrievalStrategy<T> dataRetrievalStrategy)
        {
            DataRetrievalStrategy = dataRetrievalStrategy;
        }
        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DataRetrievalStrategy.RetrieveData();
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> data = DataRetrievalStrategy.RetrieveData().GetAwaiter().GetResult();

            return data;
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

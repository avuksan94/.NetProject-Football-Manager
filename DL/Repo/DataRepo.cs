using Newtonsoft.Json;
using DL.Strategy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repo
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

        //Ne treba,za ubuduce sloziti
        //public void Add(T entity)
        //{
        //    throw new NotImplementedException();
        //}
        //
        //public void Save(T entity)
        //{
        //    throw new NotImplementedException();
        //}

    }
}

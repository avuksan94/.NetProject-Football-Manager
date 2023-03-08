﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoStrategy.Strategy
{
    public interface IDataRetrievalStrategy<T>
    {
        Task<IEnumerable<T>> RetrieveData();
    }
}

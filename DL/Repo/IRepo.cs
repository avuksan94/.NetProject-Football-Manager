using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repo
{
    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        //T GetById(int id);
        //void Add(T entity);

        //void Save(T entity);
    }
}

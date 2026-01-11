using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> Get();
        T Get(int id);
        bool Create(T obj);
        bool Update(T obj);
        bool Delete(int id);
    }
}

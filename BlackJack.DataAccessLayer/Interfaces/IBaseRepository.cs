using System;
using System.Collections.Generic;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T item);
        void Delete(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        T Get(int id);
      
        IEnumerable<T> GetAll();
        void Save();
        void Update(T item);
        void Dispose();
    }
}
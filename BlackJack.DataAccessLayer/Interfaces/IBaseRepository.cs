using System;
using System.Collections.Generic;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T item);
        long CreateAndReturnId(T item);
        void CreateMany(List<T> item);
        void Delete(long id);
        T Get(long id);
        IEnumerable<T> GetAll();
        void Update(T item);
        void UpdateMany(List<T> item);
    }
}
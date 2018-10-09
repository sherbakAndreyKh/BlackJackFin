using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T item);
        Task<long> CreateAndReturnId(T item);
        Task CreateManyAsync(List<T> item);
        Task Delete(long id);
        Task<T> Get(long id);
        Task<List<T>> GetAll();
        Task Update(T item);
        Task UpdateManyAsync(List<T> item);
    }
}
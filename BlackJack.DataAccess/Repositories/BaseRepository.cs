using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BlackJack.DataAccess.Context;
using System.Reflection;
using BlackJack.Entities;
using Z.Dapper.Plus;
using BlackJack.DataAccess.Interfaces;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected BlackJackConnection _connection;

        public BaseRepository(BlackJackConnection connection)
        {
            _connection = connection;
        }

        public async Task<T> Get(long id)
        {
            T result;
            string query = $"SELECT * FROM {typeof(T).Name} WHERE Id = {id}";
            using (IDbConnection db = _connection.CreateConnection())
            {
                result = await db.QueryFirstOrDefaultAsync<T>(query);
            }
            return result;
        }

        public async Task<List<T>> GetAll()
        {
            IEnumerable<T> result;
            string query = $"SELECT * FROM {typeof(T).Name}";
            using (IDbConnection db = _connection.CreateConnection())
            {
             result = await db.QueryAsync<T>(query);
            }
            return result.ToList();
        }

        public async Task Create(T item)
        {
            IEnumerable<string> columns = GetColums();
            string stringOfColumns = string.Join(", ", columns);
            string stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));

            string query = $"INSERT INTO {typeof(T).Name} ({stringOfColumns}) VALUES ({stringOfParameters})";

            using (IDbConnection db = _connection.CreateConnection())
            {
                await db.ExecuteAsync(query, item);
            }
        }

        public async Task<long> CreateAndReturnId(T item)
        {
            long id;
            IEnumerable<string> columns = GetColums();
            string stringOfColumns = string.Join(", ", columns);
            string stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            string query = $@"INSERT INTO {typeof(T).Name} ({stringOfColumns}) VALUES ({stringOfParameters});
                          SELECT CAST (SCOPE_IDENTITY() AS int)";

            using (IDbConnection db = _connection.CreateConnection())
            {
                id = await db.QueryFirstOrDefaultAsync<int>(query, item);
            }
            return id;
        }

        protected void CreateMany(List<T> item)
        {
            DapperPlusManager.Entity<T>().Table(typeof(T).Name);
            using (IDbConnection db = _connection.CreateConnection())
            {
                db.BulkInsert(item);
            }
        }

        public async Task CreateManyAsync(List<T> item)
        {
            await Task.Run(() => CreateMany(item));
        }

        public async Task Delete(long id)
        {
            string query = $"DELETE FROM {typeof(T).Name} WHERE id = {id}";
            using (IDbConnection db = _connection.CreateConnection())
            {
               await db.ExecuteAsync(query);
            }
        }

        public async Task Update(T item)
        {
            IEnumerable<string> colums = GetColums();
            var stringColumns = string.Join(",", colums.Select(x => $"{x}= @{x}"));
            var query = $"UPDATE {typeof(T).Name} SET {stringColumns} WHERE Id = @Id";

            using (IDbConnection db = _connection.CreateConnection())
            {
               await db.ExecuteAsync(query, item);
            }
        }

        protected void UpdateMany(List<T> item)
        {
            DapperPlusManager.Entity<T>().Table(typeof(T).Name);
            using (IDbConnection db = _connection.CreateConnection())
            {
                db.BulkUpdate(item);
            }
        }

        public async Task UpdateManyAsync(List<T> item)
        {
            await Task.Run(() => UpdateMany(item));
        }

        private IEnumerable<string> GetColums()
        {
            IEnumerable<string> result;
            result = typeof(T).GetProperties().Where(x => x.Name != "Id" && !x.PropertyType.GetTypeInfo().IsGenericType).Select(x => x.Name);
            return result;
        }
    }
}

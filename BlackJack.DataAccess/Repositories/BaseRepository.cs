using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BlackJack.DataAccess.Context;
using System.Reflection;
using BlackJack.Entities;
using Z.Dapper.Plus;
using BlackJack.DataAccess.Interfaces;

namespace BlackJack.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected BlackJackConnection _connection;

        public BaseRepository(BlackJackConnection connection)
        {
            _connection = connection;
        }

        public T Get(long id)
        {
            T result;
            string query = $"SELECT * FROM {typeof(T).Name} WHERE Id = {id}";
            using (IDbConnection db = _connection.CreateConnection())
            {
               result = db.Query<T>(query).SingleOrDefault();
            }
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> result;
            string query = $"SELECT * FROM {typeof(T).Name}";
            using (IDbConnection db = _connection.CreateConnection())
            {
             result = db.Query<T>(query);
            }
            return result;
        }

        public void Create(T item)
        {
            IEnumerable<string> columns = GetColums();
            string stringOfColumns = string.Join(", ", columns);
            string stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));

            string query = $"INSERT INTO {typeof(T).Name} ({stringOfColumns}) VALUES ({stringOfParameters})";

            using (IDbConnection db = _connection.CreateConnection())
            {
                db.Execute(query, item);
            }
        }

        public long CreateAndReturnId(T item)
        {
            long id;
            IEnumerable<string> columns = GetColums();
            string stringOfColumns = string.Join(", ", columns);
            string stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            string query = $@"INSERT INTO {typeof(T).Name} ({stringOfColumns}) VALUES ({stringOfParameters});
                          SELECT CAST (SCOPE_IDENTITY() AS int)";

            using (IDbConnection db = _connection.CreateConnection())
            {
                id = db.Query<int>(query, item).SingleOrDefault();
            }
            return id;
        }

        public void CreateMany(List<T> item)
        {
            DapperPlusManager.Entity<T>().Table(typeof(T).Name);

            using (IDbConnection db = _connection.CreateConnection())
            {
                db.BulkInsert(item);
            }
        }

        public void Delete(long id)
        {
            string query = $"DELETE FROM {typeof(T).Name} where id = {id}";
            using (IDbConnection db = _connection.CreateConnection())
            {
                db.Execute(query);
            }
        }

        public void Update(T item)
        {
            IEnumerable<string> colums = GetColums();
            var stringColumns = string.Join(",", colums.Select(x => $"{x}= @{x}"));
            var query = $"UPDATE {typeof(T).Name} SET {stringColumns} WHERE Id = @Id";

            using (IDbConnection db = _connection.CreateConnection())
            {
                db.Execute(query, item);
            }
        }

        public void UpdateMany(List<T> item)
        {
            DapperPlusManager.Entity<T>().Table(typeof(T).Name);
            using (IDbConnection db = _connection.CreateConnection())
            {
                db.BulkUpdate(item);
            }
        }

        private IEnumerable<string> GetColums()
        {
            IEnumerable<string> result;
            result = typeof(T).GetProperties().Where(x => x.Name != "Id" && !x.PropertyType.GetTypeInfo().IsGenericType).Select(x => x.Name);
            return result;
        }
    }
}

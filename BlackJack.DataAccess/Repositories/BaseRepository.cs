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
            using (IDbConnection db = _connection.CreateConnection())
            {
                return db.Query<T>($"SELECT * FROM {typeof(T).Name} WHERE Id = @id", new { id }).SingleOrDefault();
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (IDbConnection db = _connection.CreateConnection())
            {
                return db.Query<T>($"SELECT * FROM {typeof(T).Name}");
            }
        }

        public void Create(T item)
        {
            var columns = GetColums();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));

            var query = $"INSERT INTO {typeof(T).Name} ({stringOfColumns}) VALUES ({stringOfParameters})";

            using (IDbConnection db = _connection.CreateConnection())
            {
                db.Execute(query, item);
            }
        }

        public long CreateAndReturnId(T item)
        {
            long id;
            var columns = GetColums();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = $@"INSERT INTO {typeof(T).Name} ({stringOfColumns}) VALUES ({stringOfParameters});
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
            using (IDbConnection db = _connection.CreateConnection())
            {
                db.Execute($"DELETE FROM {typeof(T).Name} where id = @id", new { id });
            }
        }

        public void Update(T item)
        {
            var colums = GetColums();
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
            return typeof(T).GetProperties().Where(x => x.Name != "Id" && !x.PropertyType.GetTypeInfo().IsGenericType).Select(x => x.Name);
        }
    }
}

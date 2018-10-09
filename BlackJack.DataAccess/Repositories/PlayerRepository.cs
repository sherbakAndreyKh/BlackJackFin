using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public async Task<List<Player>> GetQuantityByRole(int quantity, int role)
        {
            IEnumerable<Player> result;
            string query = $"SELECT TOP {quantity} * FROM Player WHERE Role={role} ";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = await db.QueryAsync<Player>(query);
            }
            return result.ToList();
        }

        public async Task<Player> GetPlayerByPlayerName(string playerName)
        {
            Player result;
            string query = $"SELECT * FROM Player WHERE Name ='{playerName}'";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = await db.QueryFirstOrDefaultAsync<Player>(query);
            }
            return result;
        }

        public async Task<List<Player>> GetAllPlayersByRole(Role role)
        {
            IEnumerable<Player> result;
            string query = $"SELECT * FROM Player WHERE Role = {(int)role}";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = await db.QueryAsync<Player>(query);
            }
            return result.ToList();
        }

        public async Task<Player> GetFirstPlayerByRole(Role role)
        {
            Player result;
            string query = $"SELECT * FROM Player WHERE Role = {(int)role}";
            using (IDbConnection db = _connection.CreateConnection())
            {
                result = await db.QueryFirstOrDefaultAsync<Player>(query);
            }
            return result;
        }

        public async Task<long> GetPlayerIdByPlayerName(string playerName)
        {
            long result;
            string query = $"SELECT Id FROM Player WHERE Name = '{playerName}'";
            using (IDbConnection db = _connection.CreateConnection())
            {
                result = await db.QueryFirstOrDefaultAsync<long>(query);
            }
            return result;
        }
    }
}

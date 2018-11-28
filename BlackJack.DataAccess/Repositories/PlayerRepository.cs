using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<List<Player>> GetQuantityByRole(int quantity, int role)
        {
            IEnumerable<Player> result;
            string query = $"SELECT TOP {quantity} * FROM Player WHERE Role = @Role";

            using (IDbConnection db = CreateConnection(_connectionString))
            {
                result = await db.QueryAsync<Player>(query, new { Role = role });
            }
            return result.ToList();
        }

        public async Task<Player> GetPlayerByPlayerName(string playerName)
        {
            Player result;
            string query = $"SELECT TOP 1 * FROM Player WHERE Name = @Name";

            using (IDbConnection db = CreateConnection(_connectionString))
            {
                result = await db.QueryFirstOrDefaultAsync<Player>(query, new { Name = playerName});
            }
            return result;
        }

        public async Task<List<Player>> GetAllPlayersByRole(PlayerRole role)
        {
            IEnumerable<Player> result;
            string query = $"SELECT * FROM Player WHERE Role = @Role";

            using (IDbConnection db = CreateConnection(_connectionString))
            {
                result = await db.QueryAsync<Player>(query, new { Role = (int)role});
            }
            return result.ToList();
        }

        public async Task<Player> GetFirstPlayerByRole(PlayerRole role)
        {
            Player result;
            string query = $"SELECT TOP 1 * FROM Player WHERE Role = @Role";
            using (IDbConnection db = CreateConnection(_connectionString))
            {
                result = await db.QueryFirstOrDefaultAsync<Player>(query, new { Role = (int)role });
            }
            return result;
        }

        public async Task<long> GetPlayerIdByPlayerName(string playerName)
        {
            long result;
			//TODO: передаешь параметр не безопасно +
            string query = $"SELECT TOP 1 Id FROM Player WHERE Name = @playerName";
            using (IDbConnection db = CreateConnection(_connectionString))
            {
                result = await db.QueryFirstOrDefaultAsync<long>(query, new { playerName });
            }
            return result;
        }
    }
}

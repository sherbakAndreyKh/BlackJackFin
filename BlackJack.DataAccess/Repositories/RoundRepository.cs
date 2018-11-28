using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<long> GetNewRoundNumber(long gameId)
        {
            long result;
            string query = $"SELECT COUNT (*) FROM Round WHERE GameId=@GameId";

            using (IDbConnection db = CreateConnection(_connectionString))
            {
                result = await db.QueryFirstOrDefaultAsync<long>(query, new { GameId = gameId });
            }
            return result + 1;
        }

        public async Task<IEnumerable<Round>> GetRoundtByPlayerId(long playerId)
        {
            IEnumerable<Round> result;
            string query = $"SELECT * FROM Round WHERE GameId=@PlayerId";

            using (IDbConnection db = CreateConnection(_connectionString))
            {
                result = await db.QueryAsync<Round>(query, new { PlayerId = playerId });
            }
            return result;
        }
    }
}

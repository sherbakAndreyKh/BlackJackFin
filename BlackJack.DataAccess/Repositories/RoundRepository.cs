using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public async Task<long> GetNewRoundNumber(long gameId)
        {
            long result;
            string query = $"SELECT COUNT (*) FROM Round WHERE GameId={gameId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = await db.QueryFirstOrDefaultAsync<long>(query);
            }
            return result + 1;
        }

        public async Task<IEnumerable<Round>> GetRoundtByPlayerId(long playerId)
        {
            IEnumerable<Round> result;
            string query = $"SELECT * FROM Round WHERE GameId={playerId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = await db.QueryAsync<Round>(query);
            }
            return result;
        }
    }
}

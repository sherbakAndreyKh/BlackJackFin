using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BlackJack.DataAccess.Repositories
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public long ReturnNewRoundNumber(long gameId)
        {
            long result;
            string query = $"SELECT COUNT (*) FROM Round WHERE GameId={gameId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = db.QuerySingle<long>(query);
            }
            return result + 1;
        }

        public List<Round> GetRoundtWithPlayerId(long playerId)
        {
            List<Round> result;
            string query = $"SELECT * FROM Round WHERE GameId={playerId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = db.Query<Round>(query).ToList();
            }
            return result;
        }
    }
}

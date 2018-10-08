using BlackJack.DataAccess.Context;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerRoundHandRepository : BaseRepository<PlayerRoundHand>, IPlayerRoundHandRepository
    {
        public PlayerRoundHandRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public PlayerRoundHand GetPlayerRoundHandByPlayerAndRoundId(long playerId, long roundId)
        {
            PlayerRoundHand result;
            var query = $"SELECT * FROM PlayerRoundHand WHERE RoundId={roundId} AND PlayerId={playerId}";

            using (IDbConnection db = _connection.CreateConnection())
            {
                result = db.Query<PlayerRoundHand>(query).FirstOrDefault();
            }
            return result;
        }

        public IEnumerable<PlayerRoundHand> GetPLayerRoundHandListByRoundId(long roundId)
        {
            IEnumerable<PlayerRoundHand> result;
            string query = $"SELECT * FROM PlayerRoundHand WHERE RoundId={roundId}";
            using (IDbConnection db = _connection.CreateConnection())
            {
                result = db.Query<PlayerRoundHand>(query);
            }
            return result;
        }
    }
}

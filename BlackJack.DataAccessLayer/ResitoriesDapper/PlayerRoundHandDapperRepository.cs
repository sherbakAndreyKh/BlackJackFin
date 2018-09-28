using BlackJack.DataAccessLayer.Context;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;

namespace BlackJack.DataAccessLayer.ResitoriesDapper
{
    public class PlayerRoundHandDapperRepository : BaseDapperRepository<PlayerRoundHand>, IPlayerRoundHandRepository
    {
        public PlayerRoundHandDapperRepository(BlackJackConnection connection) : base(connection)
        {
        }

        public PlayerRoundHand GetWithPlayerAndRoundId(long playerId, long roundId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PlayerRoundHand> FindPLayerRoundHandWithRoundId(long roundId)
        {
            using (IDbConnection db = _connection.CreateConnection())
            {
                return db.Query<PlayerRoundHand>("SELECT * FROM PlayerRoundHand WHERE RoundId=@roundId", new { roundId });
            }
        }
    }
}

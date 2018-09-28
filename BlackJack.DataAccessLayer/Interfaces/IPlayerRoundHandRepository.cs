using BlackJack.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IPlayerRoundHandRepository : IBaseRepository<PlayerRoundHand>
    {
        PlayerRoundHand GetWithPlayerAndRoundId(long playerId, long roundId);
        IEnumerable<PlayerRoundHand> FindPLayerRoundHandWithRoundId(long roundId);
    }
}

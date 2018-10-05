using System.Collections.Generic;
using BlackJack.Entities;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRoundHandRepository : IBaseRepository<PlayerRoundHand>
    {
        IEnumerable<PlayerRoundHand> FindPLayerRoundHandWithRoundId(long roundId);
        PlayerRoundHand GetWithPlayerAndRoundId(long playerId, long roundId);
    }
}
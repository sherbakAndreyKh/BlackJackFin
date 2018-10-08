using System.Collections.Generic;
using BlackJack.Entities;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRoundHandRepository : IBaseRepository<PlayerRoundHand>
    {
        IEnumerable<PlayerRoundHand> GetPLayerRoundHandListByRoundId(long roundId);
        PlayerRoundHand GetPlayerRoundHandByPlayerAndRoundId(long playerId, long roundId);
    }
}
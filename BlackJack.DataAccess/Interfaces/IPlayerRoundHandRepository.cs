using System.Collections.Generic;
using System.Threading.Tasks;
using BlackJack.Entities;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRoundHandRepository : IBaseRepository<PlayerRoundHand>
    {
        Task<PlayerRoundHand> GetPlayerRoundHandByPlayerAndRoundId(long playerId, long roundId);
        Task<List<PlayerRoundHand>> GetPLayerRoundHandListByRoundId(long roundId);
    }
}
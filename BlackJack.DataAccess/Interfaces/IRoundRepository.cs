using BlackJack.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IRoundRepository : IBaseRepository<Round>
    {
        Task<long> GetNewRoundNumber(long gameId);
        Task<IEnumerable<Round>> GetRoundtByPlayerId(long playerId);
    }
}
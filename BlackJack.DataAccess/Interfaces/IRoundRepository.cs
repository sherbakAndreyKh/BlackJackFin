using BlackJack.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IRoundRepository : IBaseRepository<Round>
    {
        long GetNewRoundNumber(long id);
        List<Round> GetRoundtByPlayerId(long id);
    }
}
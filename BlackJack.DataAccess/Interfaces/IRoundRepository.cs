using BlackJack.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IRoundRepository : IBaseRepository<Round>
    {
        long ReturnNewRoundNumber(long id);
        List<Round> GetRoundtWithPlayerId(long id);
    }
}
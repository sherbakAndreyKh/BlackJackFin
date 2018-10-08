using BlackJack.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        long ReturnNewGameNumber(long playerId);
        List<Game> GetGamestWithPlayerId(long playerId);
    }
}
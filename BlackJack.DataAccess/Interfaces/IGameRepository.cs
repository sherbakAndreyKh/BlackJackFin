using BlackJack.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        long GetNewGameNumber(long playerId);
        List<Game> GetGamesByPlayerId(long playerId);
    }
}
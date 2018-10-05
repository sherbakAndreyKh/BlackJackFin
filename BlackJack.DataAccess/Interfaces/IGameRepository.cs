using BlackJack.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        int ReturnNewGameNumber(long id);
        List<Game> GetGamestWithPlayerId(long id);
    }
}
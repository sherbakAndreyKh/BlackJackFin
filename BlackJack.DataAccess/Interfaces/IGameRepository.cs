using BlackJack.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task<long> GetNewGameNumber(long playerId);
        Task<List<Game>> GetGamesByPlayerId(long playerId);
    }
}
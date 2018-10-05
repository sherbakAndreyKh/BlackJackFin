using System.Collections.Generic;
using BlackJack.Entities;
using BlackJack.Entities.Enums;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        IEnumerable<Player> GetQuantityWithRole(int quantity, int role);
        Player FindPlayerWithPlayerName(string Name);
    }
}
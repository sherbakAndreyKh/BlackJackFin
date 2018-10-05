using System.Collections.Generic;
using BlackJack.Entities;
using BlackJack.Entities.Enums;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Player FindPlayerWithPlayerName(string Name);
        IEnumerable<Player> GetQuantityWithRole(int quantity, int role);
        List<Player> GetPlayersWithRole(Role role);
    }
}
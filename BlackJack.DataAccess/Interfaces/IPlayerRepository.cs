using System.Collections.Generic;
using BlackJack.Entities;
using BlackJack.Entities.Enums;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Player GetPlayerByPlayerName(string Name);
        IEnumerable<Player> GetQuantityByRole(int quantity, int role);
        List<Player> GetPlayersByRole(Role role);
    }
}
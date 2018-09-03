using System.Collections.Generic;
using BlackJack.Entities;
using BlackJack.Entities.Enums;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        int CreateAndReturnId(Player item);
        IEnumerable<Player> GetQuantityWithRole(int quantity, int role);
    }
}
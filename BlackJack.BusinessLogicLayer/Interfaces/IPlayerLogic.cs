using System;
using System.Collections.Generic;
using BlackJack.Entities;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface IPlayerLogic
    {
        void Create(Player item);
        int CreateAndReturnId(Player item);
        Player Get(int id);
        void Delete(int id);
        IEnumerable<Player> Find(Func<Player, bool> predicate);
        IEnumerable<Player> GatAll();
        IEnumerable<Player> GetQuentityWithRole(int quantity, int role);
        void Save();
        void Update(Player item);
    }
}
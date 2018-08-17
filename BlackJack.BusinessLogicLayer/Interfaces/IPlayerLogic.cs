using System;
using System.Collections.Generic;
using BlackJack.Entities.Participant;

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
        void Save();
        void Update(Player item);
    }
}
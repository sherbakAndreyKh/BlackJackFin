using System;
using System.Collections.Generic;
using BlackJack.Entities;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface IPlayerPropertiesLogic
    {
        void Create(PlayerProperties item);
        void Delete(int id);
        IEnumerable<PlayerProperties> Find(Func<PlayerProperties, bool> predicate);
        IEnumerable<PlayerProperties> GatAll();
        PlayerProperties Get(int id);
        PlayerProperties GetWithPlayerAndRoundId(int playerId, int roundId);
        void Save();
        void Update(PlayerProperties item);
    }
}
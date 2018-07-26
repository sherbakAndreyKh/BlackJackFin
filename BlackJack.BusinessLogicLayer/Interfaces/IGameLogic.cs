using System;
using System.Collections.Generic;
using BlackJack.Entities.History;

namespace BlackJack.BusinessLogicLayer.BusinessLogic
{
    public interface IGameLogic
    {
        void Create(Game item);
        int CreateAndReturnId(Game item);
        void Delete(int id);
        IEnumerable<Game> Find(Func<Game, bool> predicate);
        IEnumerable<Game> GatAll();
        void Save();
        void Update(Game item);
    }
}
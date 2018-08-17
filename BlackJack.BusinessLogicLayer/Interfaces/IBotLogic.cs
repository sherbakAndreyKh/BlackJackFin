using System;
using System.Collections.Generic;
using BlackJack.Entities.Participant;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface IBotLogic
    {
        void Create(Bot item);
        void Delete(int id);
        Bot Get(int id);
        IEnumerable<Bot> Find(Func<Bot, bool> predicate);
        IEnumerable<Bot> GatAll();
        void Save();
        void Update(Bot item);
    }
}
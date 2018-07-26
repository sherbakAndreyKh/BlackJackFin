using System;
using System.Collections.Generic;
using BlackJack.Entities.Participant;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface IDealerLogic
    {
        void Create(Dealer item);
        void Delete(int id);
        IEnumerable<Dealer> Find(Func<Dealer, bool> predicate);
        IEnumerable<Dealer> GatAll();
        void Save();
        void Update(Dealer item);
    }
}
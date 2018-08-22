using System;
using System.Collections.Generic;
using BlackJack.Entities.History;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface IRoundLogic
    {
        void Create(Round item);
        void Delete(int id);
        IEnumerable<Round> Find(Func<Round, bool> predicate);
        IEnumerable<Round> GetAll();
        Round Get(int id);
        int GetAndReturnId(Round item);
        int ReturnNewRoundNumber(int id);
        void Save();
        void Update(Round item);
    }
}
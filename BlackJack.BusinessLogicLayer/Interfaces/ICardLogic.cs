using System;
using System.Collections.Generic;
using BlackJack.Entities;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface ICardLogic
    {
        void Create(Card item);
        void Delete(int id);
        IEnumerable<Card> Find(Func<Card, bool> predicate);
        IEnumerable<Card> GetAll();
        void Save();
        void Update(Card item);
    }
}
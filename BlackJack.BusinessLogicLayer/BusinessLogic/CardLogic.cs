using System;
using System.Collections.Generic;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities;

namespace BlackJack.BusinessLogicLayer.BusinessLogic
{
    public class CardLogic : ICardLogic
    {
        // Fields

        ICardRepository _cardRepository;

        // Constructors
        public CardLogic()
        {
        }

        public CardLogic(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        // Methods
        public IEnumerable<Card> GetAll()
        {
            return _cardRepository.GetAll();
        }

        public Card Get(int id)
        {
            return _cardRepository.Get(id);
        }

        public IEnumerable<Card> Find(Func<Card, Boolean> predicate)
        {
            return _cardRepository.Find(predicate);
        }

        public void Create(Card item)
        {
            _cardRepository.Create(item);
        }

        public void Update(Card item)
        {
            _cardRepository.Update(item);
        }

        public void Delete(int id)
        {
            _cardRepository.Delete(id);
        }

        public void Save()
        {
            _cardRepository.Save();
        }
    }
}

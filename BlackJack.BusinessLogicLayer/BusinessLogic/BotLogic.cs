using System;
using System.Collections.Generic;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities.Participant;

namespace BlackJack.BusinessLogicLayer.BusinessLogic
{
    public class BotLogic : IBotLogic
    {
        IBotRepository _botRepository;

        public BotLogic()
        {
        }

        public BotLogic(IBotRepository botRepository)
        {
            _botRepository = botRepository;
        }

        public Bot Get(int id)
        {
            return _botRepository.Get(id);
        }

        public IEnumerable<Bot> GatAll()
        {
            return _botRepository.GetAll();
        }

        public IEnumerable<Bot> Find(Func<Bot, Boolean> predicate)
        {
            return _botRepository.Find(predicate);
        }

        public void Create(Bot item)
        {
            _botRepository.Create(item);
        }

        public void Update(Bot item)
        {
            _botRepository.Update(item);
        }

        public void Delete(int id)
        {
            _botRepository.Delete(id);
        }

        public void Save()
        {
            _botRepository.Save();
        }

        
    }
}

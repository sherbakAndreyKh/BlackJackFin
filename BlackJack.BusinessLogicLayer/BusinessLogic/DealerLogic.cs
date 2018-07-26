using System;
using System.Collections.Generic;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities.Participant;

namespace BlackJack.BusinessLogicLayer.BusinessLogic
{
    public class DealerLogic : IDealerLogic
    {
        IDealerRepository _dealerRepository;

        public DealerLogic()
        {
        }

        public DealerLogic(IDealerRepository dealerRepository)
        {
            _dealerRepository = dealerRepository;
        }

        public IEnumerable<Dealer> GatAll()
        {
            return _dealerRepository.GetAll();
        }

        public IEnumerable<Dealer> Find(Func<Dealer, Boolean> predicate)
        {
            return _dealerRepository.Find(predicate);
        }

        public void Create(Dealer item)
        {
            _dealerRepository.Create(item);
        }

        public void Update(Dealer item)
        {
            _dealerRepository.Update(item);
        }

        public void Delete(int id)
        {
            _dealerRepository.Delete(id);
        }

        public void Save()
        {
            _dealerRepository.Save();
        }
    }
}

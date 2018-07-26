using System;
using System.Collections.Generic;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities.History;

namespace BlackJack.BusinessLogicLayer.BusinessLogic
{
    public class RoundLogic : IRoundLogic
    {
        IRoundRepository _roundRepository;

        public RoundLogic()
        {
        }

        public RoundLogic(IRoundRepository roundRepository)
        {
            _roundRepository = roundRepository;
        }

        public IEnumerable<Round> GatAll()
        {
            return _roundRepository.GetAll();
        }

        public IEnumerable<Round> Find(Func<Round, Boolean> predicate)
        {
            return _roundRepository.Find(predicate);
        }

        public void Create(Round item)
        {
            _roundRepository.Create(item);
        }

        public void Update(Round item)
        {
            _roundRepository.Update(item);
        }

        public void Delete(int id)
        {
            _roundRepository.Delete(id);
        }

        public void Save()
        {
            _roundRepository.Save();
        }

    }
}

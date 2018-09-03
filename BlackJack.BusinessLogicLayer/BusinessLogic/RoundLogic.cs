using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities.History;

namespace BlackJack.BusinessLogicLayer.BusinessLogic
{
    public class RoundLogic : IRoundLogic
    {
        //Fields
        IRoundRepository _roundRepository;

        // Constructors
        public RoundLogic()
        {
        }

        public RoundLogic(IRoundRepository roundRepository)
        {
            _roundRepository = roundRepository;
        }

        //Methods
        public IEnumerable<Round> GetAll()
        {
            return _roundRepository.GetAll();
        }

        public Round Get(int id)
        {
            return _roundRepository.Get(id);
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

        public int GetAndReturnId(Round item)
        {
            return _roundRepository.CreateAndReturnId(item);
        }

        public int ReturnNewRoundNumber(int id)
        {
            return _roundRepository.ReturnNewRoundNumber(id);
        }

        public IQueryable<Round> Include()
        {
            return _roundRepository.Include();
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

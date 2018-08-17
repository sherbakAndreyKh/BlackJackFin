using System;
using System.Collections.Generic;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities.History;
using BlackJack.BusinessLogicLayer.Interfaces;

namespace BlackJack.BusinessLogicLayer.BusinessLogic
{
    public class GameLogic : IGameLogic
    {
        IGameRepository _gameRepository;

        public GameLogic()
        {
        }

        public GameLogic(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public int CreateAndReturnId(Game item)
        {
            return _gameRepository.CreateAndReturnId(item);
        }

        public Game Get(int id)
        {
            return _gameRepository.Get(id);
        }

        public IEnumerable<Game> GatAll()
        {
            return _gameRepository.GetAll();
        }

        public IEnumerable<Game> Find(Func<Game, Boolean> predicate)
        {
            return _gameRepository.Find(predicate);
        }

        public void Create(Game item)
        {
            _gameRepository.Create(item);
        }

        public void Update(Game item)
        {
            _gameRepository.Update(item);
        }

        public void Delete(int id)
        {
            _gameRepository.Delete(id);
        }

        public void Save()
        {
            _gameRepository.Save();
        }

        
    }
}

using System;
using System.Collections.Generic;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities;

namespace BlackJack.BusinessLogicLayer.BusinessLogic
{
    public class PlayerLogic : IPlayerLogic
    {
        IPlayerRepository _playerRepository;

        public PlayerLogic()
        {
        }

        public PlayerLogic(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public int CreateAndReturnId(Player item)
        {
            return _playerRepository.CreateAndReturnId(item);
        }

        public Player Get(int Id)
        {
            return _playerRepository.Get(Id);
        }

        public IEnumerable<Player> GetAll()
        {
            return _playerRepository.GetAll();
        }

        public IEnumerable<Player> GetQuantityWithRole(int quantity, int role)
        {
            return _playerRepository.GetQuantityWithRole(quantity, role);
        }

        public IEnumerable<Player> Find(Func<Player, Boolean> predicate)
        {
            return _playerRepository.Find(predicate);
        }

        public void Create(Player item)
        {
            _playerRepository.Create(item);
        }

        public void Update(Player item)
        {
            _playerRepository.Update(item);
        }

        public void Delete(int id)
        {
            _playerRepository.Delete(id);
        }

        public void Save()
        {
            _playerRepository.Save();
        }
    }

}

using System;
using System.Collections.Generic;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities.Participant;

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

        public IEnumerable<Player> GatAll()
        {
            return _playerRepository.GetAll();
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

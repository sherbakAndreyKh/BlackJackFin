using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities;

namespace BlackJack.BusinessLogicLayer.BusinessLogic
{
    public class PlayerRoundHandLogic : IPlayerRoundHandLogic
    {
        IPlayerRoundHandRepository _playerRoundHandRepository;

        public PlayerRoundHandLogic()
        {
        }
        
        public PlayerRoundHandLogic(IPlayerRoundHandRepository playerRoundHandRepository)
        {
            _playerRoundHandRepository = playerRoundHandRepository;
        }

        public PlayerRoundHand Get(int id)
        {
            return _playerRoundHandRepository.Get(id);
        }

        public PlayerRoundHand GetWithPlayerAndRoundId(int playerId, int roundId)
        {
            return _playerRoundHandRepository.GetWithPlayerAndRoundId(playerId, roundId);
        }

        public IEnumerable<PlayerRoundHand> GetAll()
        {
            return _playerRoundHandRepository.GetAll();
        }

        public IEnumerable<PlayerRoundHand> Find(Func<PlayerRoundHand, Boolean> predicate)
        {
            return _playerRoundHandRepository.Find(predicate);
        }

        public void Create(PlayerRoundHand item)
        {
            _playerRoundHandRepository.Create(item);
        }
        
        public void CreateMany(List<PlayerRoundHand> item)
        {
            _playerRoundHandRepository.CreateMany(item);
        }

        public void Update(PlayerRoundHand item)
        {
            _playerRoundHandRepository.Update(item);
        }

        public void UpdateMany(List<PlayerRoundHand> item)
        {
            _playerRoundHandRepository.UpdateMany(item);
        }

        public void Delete(int id)
        {
            _playerRoundHandRepository.Delete(id);
        }

        public void Save()
        {
            _playerRoundHandRepository.Save();
        }
    }
}

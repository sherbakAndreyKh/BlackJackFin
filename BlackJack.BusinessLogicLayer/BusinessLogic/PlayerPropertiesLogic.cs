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
    public class PlayerPropertiesLogic : IPlayerPropertiesLogic
    {
        // Fields
        IPlayerPropertiesRepository _playerPropertiesRepository;

        // Constructors
        public PlayerPropertiesLogic()
        {
        }
        
        public PlayerPropertiesLogic(IPlayerPropertiesRepository playerPropertiesRepository)
        {
            _playerPropertiesRepository = playerPropertiesRepository;
        }

        // Methods
        public PlayerProperties Get(int id)
        {
            return _playerPropertiesRepository.Get(id);
        }

        public PlayerProperties GetWithPlayerAndRoundId(int playerId, int roundId)
        {
            return _playerPropertiesRepository.GetWithPlayerAndRoundId(playerId, roundId);
        }

        public IEnumerable<PlayerProperties> GatAll()
        {
            return _playerPropertiesRepository.GetAll();
        }

        public IEnumerable<PlayerProperties> Find(Func<PlayerProperties, Boolean> predicate)
        {
            return _playerPropertiesRepository.Find(predicate);
        }

        public void Create(PlayerProperties item)
        {
            _playerPropertiesRepository.Create(item);
        }

        public void Update(PlayerProperties item)
        {
            _playerPropertiesRepository.Update(item);
        }

        public void Delete(int id)
        {
            _playerPropertiesRepository.Delete(id);
        }

        public void Save()
        {
            _playerPropertiesRepository.Save();
        }

    }
}

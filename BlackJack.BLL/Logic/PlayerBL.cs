using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities.Participant;

namespace BlackJack.BLL.Logic
{
    public class PlayerBL : IPlayerBL
    {
        IPlayerRepository _playerRepository;

        public PlayerBL(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public int AddAndReturnId(Player playerName)
        {
            var playerId = _playerRepository.CreateAndReturnId(playerName);
            
            return playerId;
        }
    }
}

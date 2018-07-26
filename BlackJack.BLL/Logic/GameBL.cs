using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.Entities.History;

namespace BlackJack.BLL.Logic
{
    public class GameBL : IGameBL
    {
        IGameRepository _gameRepository;

        public GameBL(IGameRepository gameRepository, DataAccessLayer.Interfaces.IBotRepository repository)
        {
            _gameRepository = gameRepository;
          
        }

        public int Add(Game GameItem, int playerId)
        {
            _gameRepository.Create(new Game { AmountPlayers = GameItem.AmountPlayers, PlayerId = playerId });
            _gameRepository.Save();

            return GameItem.AmountPlayers;
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels;
using BlackJack.Entities.Participant;
using BlackJack.Entities.History;
using BlackJack.Services.Interfaces;
using BlackJack.BLL.Interfaces;

namespace BlackJack.Services.Services
{
    public class GameStartService : IGameStartService
    {
        private IGameBL _gameBL;
        private IPlayerBL _playerBL; 

        public GameStartService(IGameBL gameBL, IPlayerBL playerBL)
        {
            _gameBL = gameBL;
            _playerBL = playerBL;
        }

        public int GetAndCreateGame(GameOptions gameOptions)
        {
            Player player = new Player()
            {
                Name = gameOptions.PlayerName
            };

            Game game = new Game()
            {
                AmountPlayers = gameOptions.Bots
            };

            var amount = _gameBL.Add(game, _playerBL.AddAndReturnId(player));

            return amount;
            
        }
    }
}

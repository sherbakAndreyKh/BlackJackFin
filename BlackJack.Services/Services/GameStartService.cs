using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels;
using BlackJack.Entities.Participant;
using BlackJack.Entities.History;
using BlackJack.Services.Interfaces;
using BlackJack.BusinessLogicLayer.Interfaces;

namespace BlackJack.Services.Services
{
    public class GameStartService : IGameStartService
    {
        private IGameLogic _gameLogic;
        private IPlayerLogic _playerLogic;
        

        
        public GameStartService(IGameLogic gameBL, IPlayerLogic playerBL)
        {
            _gameLogic = gameBL;
            _playerLogic = playerBL;
        }

        public Game GetAndCreateGame(GameOptions gameOptions)
        {
            Player player = new Player()
            {
                Name = gameOptions.PlayerName
            };  

            Game game = new Game()
            {
                AmountPlayers = gameOptions.Bots
            };

            _playerLogic.Create(player);
            _gameLogic.Create(game);
            _playerLogic.Save();

            return game;
        }
    }
}

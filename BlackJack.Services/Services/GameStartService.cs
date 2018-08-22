using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.History;
using BlackJack.Entities.Enums;
using BlackJack.ViewModels;
using BlackJack.Services.Interfaces;

namespace BlackJack.Services.Services
{
    public class GameStartService : IGameStartService
    {
        // Fields
        IPlayerLogic _plyerLogic;
        IGameLogic _gameLogic;
        IRoundLogic _roundLogic;

        //Constructors
        public GameStartService(IPlayerLogic playerLogic, IGameLogic gameLogic, IRoundLogic roundLogic)
        {
            _plyerLogic = playerLogic;
            _gameLogic = gameLogic;
            _roundLogic = roundLogic;
        }

        //Methods
        public GameViewModel CreateGame(GameOptionsViewModel item)
        {

            // add Player and return Id
            Player player = new Player()
            {
                Name = item.PlayerName,
                Role = Roles.Player
            };

            var playerId = _plyerLogic.CreateAndReturnId(player);


            // add Game and return Id
            Game game = new Game()
            {
                AmountPlayers = item.AmountBots + 2,
                PlayerId = playerId,
                NumberGame = _gameLogic.ReturnNewGameNumber(playerId),
            };

            var gameId = _gameLogic.CreateAndReturnId(game);

            // add Round and return Id 
            Round round = new Round()
            {
                GameId = gameId,
                NumberOfRound = _roundLogic.ReturnNewRoundNumber(gameId),
            };

            round.Players.Add(player);
            round.Players.Add(_plyerLogic.GetQuentityWithRole(1, 1).Single());
            foreach (var a in _plyerLogic.GetQuentityWithRole(item.AmountBots, 2))
            {
                round.Players.Add(a);
            }

            var roundId = _roundLogic.GetAndReturnId(round);


            // Test For tomorow
            GameViewModel gameVM = new GameViewModel()
            {
                GameNumber = game.NumberGame,
                RoundNumber = round.NumberOfRound,

            };
            foreach (var a in round.Players)
            {
                gameVM.PlayerName.Add(a.Name);
            }

            return gameVM;

        }
    }
}

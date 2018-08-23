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
        ICardLogic _cardLogic;
        IPlayerPropertiesLogic _playerPropertiesLogic;

        //Constructors
        public GameStartService(IPlayerLogic playerLogic, IGameLogic gameLogic, IRoundLogic roundLogic, ICardLogic cardLogic, IPlayerPropertiesLogic playerPropertiesLogic)
        {
            _plyerLogic = playerLogic;
            _gameLogic = gameLogic;
            _roundLogic = roundLogic;
            _cardLogic = cardLogic;
            _playerPropertiesLogic = playerPropertiesLogic;
        }

        //Methods
        public GameViewModel CreateGame(GameOptionsViewModel item)
        {

            // add Player and return Id
            Player player = new Player()
            {
                Name = item.PlayerName,
                Role = Roles.Player,
            };

            var playerId = _plyerLogic.CreateAndReturnId(player);

            // cards
            var cards = MapCards(_cardLogic.GetAll());
            List<PlayersGameViewModelItem> players = new List<PlayersGameViewModelItem>();

            players.Add(MapPlayer(_plyerLogic.Get(playerId)));
            players.Add(MapPlayer(_plyerLogic.GetQuentityWithRole(1, 1).SingleOrDefault()));
            foreach (var a in _plyerLogic.GetQuentityWithRole(item.AmountBots, 2))
            {
                players.Add(MapPlayer(a));
            }

            // add Game and return Id
            Game game = new Game()
            {
                AmountPlayers = item.AmountBots + 2,
                PlayerId = playerId,
                NumberGame = _gameLogic.ReturnNewGameNumber(playerId),
            };

            var gameId = _gameLogic.CreateAndReturnId(game);

            // add Round and return Id 
            var test = new List<Card>();
            test.Add(_cardLogic.Find(x => x.Id == 12).Single());

            Round round = new Round()
            {
                GameId = gameId,
                NumberRound = _roundLogic.ReturnNewRoundNumber(gameId),
                WinnerHand = test
            };
            
            var roundId = _roundLogic.GetAndReturnId(round);



          



            GameViewModel gameVM = new GameViewModel()
            {
                GameNumber = game.NumberGame,
                RoundNumber = round.NumberRound,
                Card = cards,
                Players = players,                
            };


            
           
            return gameVM;
        }



        // Mapping 
        protected PlayersGameViewModelItem MapPlayer(Player player)
        {
            var result = new PlayersGameViewModelItem()
            {
                Name = player.Name,
                Role = (int)player.Role
            };
            return result;
        }
        
        protected List<CardGameViewModelItem> MapCards(IEnumerable<Card> cards)
        {
            var result = new List<CardGameViewModelItem>();
            foreach (var a in cards)
            {
                var CardView = new CardGameViewModelItem()
                {
                    Name = a.Name,
                    Suit = a.Suit,
                    Value = a.Value,
                    ImgPath = a.ImgPath
                };
                result.Add(CardView);
            }
            return result;
        }


    }
}

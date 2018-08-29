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
            // add Player 
            var playerId = CheckPLayerName(item.PlayerName) ? CreatePlayerAndReturnId(item) : _plyerLogic.Find(x => x.Name == item.PlayerName).SingleOrDefault().Id;
            // add Game and return Id         
            var gameId = CreateGameAndReturnId(item, playerId);
            // add Round and return Id
            var roundId = CreateRoundAndReturnId(gameId);
            // add cards
            var cards = MapCards(_cardLogic.GetAll());

            ////add Plyer Hands
            List<Player> playersList = new List<Player>();
            playersList.Add(_plyerLogic.Get(playerId));
            playersList.Add(_plyerLogic.GetQuentityWithRole(1, 1).SingleOrDefault());
            foreach (var a in _plyerLogic.GetQuentityWithRole(item.AmountBots, 2))
            {
                playersList.Add(a);
            }

            foreach(var a in playersList)
            {
                PlayerProperties prop = new PlayerProperties();
                prop.PlayerId = a.Id;
                prop.Round_Id = roundId;
                _playerPropertiesLogic.Create(prop);
                _playerPropertiesLogic.Save();
            }

            // mappin Players
            List<PlayersGameViewModelItem> Bots = new List<PlayersGameViewModelItem>();

            foreach (var a in _plyerLogic.GetQuentityWithRole(item.AmountBots, 2))
            {
                Bots.Add(MapPlayer(a, roundId));
            }


            GameViewModel gameVM = new GameViewModel();
            gameVM.GameId = gameId;
            gameVM.RoundId = roundId;
            gameVM.GameNumber = _gameLogic.Get(gameId).NumberGame;
            gameVM.RoundNumber = _roundLogic.Get(roundId).NumberRound;
            gameVM.CardDeck = cards;
            gameVM.Player = MapPlayer(_plyerLogic.Get(playerId),roundId);
            gameVM.Dealer = MapPlayer(_plyerLogic.GetQuentityWithRole(1, 1).SingleOrDefault(),roundId);
            gameVM.Bots = Bots;
                 
            return gameVM;
        }



        private bool CheckPLayerName(string name)
        {
            foreach(var Search in _plyerLogic.GatAll())
            {
                if(Search.Name == name)
                {
                    return false;
                }
            }
            return true;
        }

        private int CreatePlayerAndReturnId(GameOptionsViewModel item)
        {
            Player player = new Player()
            {
                Name = item.PlayerName,
                Role = Roles.Player,
            };

            return _plyerLogic.CreateAndReturnId(player);
        }

        private int CreateGameAndReturnId(GameOptionsViewModel item, int playerId)
        {
            Game game = new Game()
            {
                AmountPlayers = item.AmountBots + 1,
                PlayerId = playerId,
                NumberGame = _gameLogic.ReturnNewGameNumber(playerId)
            };
            return _gameLogic.CreateAndReturnId(game);
        }

        private int CreateRoundAndReturnId(int gameId)
        {
            Round round = new Round()
            {
                GameId = gameId,
                NumberRound = _roundLogic.ReturnNewRoundNumber(gameId)
            };
            return _roundLogic.GetAndReturnId(round);
        }



        // Mapping 
        protected PlayersGameViewModelItem MapPlayer(Player player, int roundId)
        {
            var result = new PlayersGameViewModelItem()
            {
                Name = player.Name,
                Role = (int)player.Role,              
            };
            result.Properties.Add(MapProperties(_playerPropertiesLogic.GetWithPlayerAndRoundId(player.Id, roundId)));
            return result;
        }
        
        protected PlayerPropertiesGameViewModelItem MapProperties(PlayerProperties properties)
        {
            var result = new PlayerPropertiesGameViewModelItem()
            {
                PlayerId = properties.PlayerId,
                Round_Id = properties.Round_Id,
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


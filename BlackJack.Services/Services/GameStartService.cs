
using System.Collections.Generic;
using System.Linq;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.History;
using BlackJack.Entities.Enums;
using BlackJack.ViewModels;
using BlackJack.Services.Interfaces;
using BlackJack.BusinessLogicLayer.Mapping;

namespace BlackJack.Services.Services
{
    public class GameStartService : IGameStartService
    {
        // Fields
        IPlayerLogic _playerLogic;
        IGameLogic _gameLogic;
        IRoundLogic _roundLogic;
        ICardLogic _cardLogic;
        IPlayerPropertiesLogic _playerPropertiesLogic;
        GameStartServiceResponseMappProvider _mapp;

        //Constructors
        public GameStartService(IPlayerLogic playerLogic, IGameLogic gameLogic, IRoundLogic roundLogic, ICardLogic cardLogic, IPlayerPropertiesLogic playerPropertiesLogic, GameStartServiceResponseMappProvider mapp)
        {
            _playerLogic = playerLogic;
            _gameLogic = gameLogic;
            _roundLogic = roundLogic;
            _cardLogic = cardLogic;
            _playerPropertiesLogic = playerPropertiesLogic;
            _mapp = mapp;
        }


        //Methods
        public ResponseGameViewModel CreateGame(GameOptionsViewModel item)
        {
            // add Player 
            int playerId = CheckPLayerName(item.PlayerName) ? CreatePlayerAndReturnId(item) : _playerLogic.Find(x => x.Name == item.PlayerName).SingleOrDefault().Id;
            // add Game and return Id         
            int gameId = CreateGameAndReturnId(item, playerId);
            // add Round and return Id
            int roundId = CreateRoundAndReturnId(gameId);
            // add cards
            List<CardResponseGameViewModelItem> cards = _mapp.MapCards(_cardLogic.GetAll());

            ////add Plyer Hands
            var playerList = new List<Player>();
            playerList.Add(_playerLogic.Get(playerId));
            playerList.Add(_playerLogic.GetQuantityWithRole(1, 1).SingleOrDefault());

            foreach (var player in _playerLogic.GetQuantityWithRole(item.AmountBots, 2))
            {
                playerList.Add(player);
            }

            for (int i = 0; i < playerList.Count(); i++)
            {
                var property = new PlayerProperties();
                property.PlayerId = playerList[i].Id;
                property.Round_Id = roundId;
                _playerPropertiesLogic.Create(property);
                _playerPropertiesLogic.Save();
            }
           

            // mappin Players
            List<PlayersResponseGameViewModelItem> Bots = new List<PlayersResponseGameViewModelItem>();

            foreach (var player in _playerLogic.GetQuantityWithRole(item.AmountBots, 2).ToList())
            {
                Bots.Add(_mapp.MapPlayer(player, _playerPropertiesLogic.GetWithPlayerAndRoundId(playerId,roundId)));
            }


            ResponseGameViewModel gameVM = new ResponseGameViewModel();
            gameVM.Game = _mapp.MapGame(_gameLogic.Get(gameId));
            gameVM.Round = _mapp.MapRound(_roundLogic.Get(roundId));
            gameVM.CardDeck = cards;
            gameVM.Player = _mapp.MapPlayer(_playerLogic.Get(playerId), _playerPropertiesLogic.GetWithPlayerAndRoundId(playerId, roundId)); 
            gameVM.Dealer = _mapp.MapPlayer(_playerLogic.GetQuantityWithRole(1, 1).SingleOrDefault(), _playerPropertiesLogic.GetWithPlayerAndRoundId(playerId, roundId));
            gameVM.Bots = Bots;
                 
            return gameVM;
        }



        private bool CheckPLayerName(string name)
        {
            foreach(var Search in _playerLogic.GetAll())
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

            return _playerLogic.CreateAndReturnId(player);
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

    }

}


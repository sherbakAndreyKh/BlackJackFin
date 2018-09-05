
using System.Collections.Generic;
using System.Linq;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.History;
using BlackJack.Entities.Enums;
using BlackJack.Services.Interfaces;
using BlackJack.BusinessLogicLayer.Mapping;
using BlackJack;
//using BlackJack.ViewModels.ResponseModel;

namespace BlackJack.Services.Services
{
    public class GameService : IGameService
    {
        // Fields
        IPlayerLogic _playerLogic;
        IGameLogic _gameLogic;
        IRoundLogic _roundLogic;
        ICardLogic _cardLogic;
        IPlayerPropertiesLogic _playerPropertiesLogic;
        GameServiceResponseMappProvider _mapp;

        //Constructors
        public GameService(IPlayerLogic playerLogic, IGameLogic gameLogic, IRoundLogic roundLogic, ICardLogic cardLogic, IPlayerPropertiesLogic playerPropertiesLogic, GameServiceResponseMappProvider mapp)
        {
            _playerLogic = playerLogic;
            _gameLogic = gameLogic;
            _roundLogic = roundLogic;
            _cardLogic = cardLogic;
            _playerPropertiesLogic = playerPropertiesLogic;
            _mapp = mapp;
        }



        //Methods

        /// <summary>
        /// Start Game After Options Windows
        /// </summary>
        /// <param name="item"> Start Game options </param>
        /// <returns> All Game Info </returns>
        public ViewModels.ResponseModel.ResponseGameProcessGameView StartGame(ViewModels.RequestModel.RequestGameStartOptionsGameView item)
        {
            // add Player 
            int playerId = CheckPLayerName(item.PlayerName) ? CreatePlayerAndReturnId(item) : _playerLogic.Find(x => x.Name == item.PlayerName).SingleOrDefault().Id;
            // add Game and return Id         
            int gameId = CreateGameAndReturnId(item, playerId);
            // add Round and return Id
            int roundId = CreateRoundAndReturnId(gameId);
            // add cards
            List<ViewModels.ResponseModel.CardGameProcessGameViewItem> cards = _mapp.MapCards(_cardLogic.GetAll());

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
            List<ViewModels.ResponseModel.PlayerGameProcessGameViewItem> Bots = new List<ViewModels.ResponseModel.PlayerGameProcessGameViewItem>();

            foreach (var player in _playerLogic.GetQuantityWithRole(item.AmountBots, 2).ToList())
            {
                Bots.Add(_mapp.MapPlayer(player, _playerPropertiesLogic.GetWithPlayerAndRoundId(player.Id,roundId)));
            }


            ViewModels.ResponseModel.ResponseGameProcessGameView gameVM = new ViewModels.ResponseModel.ResponseGameProcessGameView();
            gameVM.Game = _mapp.MapGame(_gameLogic.Get(gameId));
            gameVM.Round = _mapp.MapRound(_roundLogic.Get(roundId));
            gameVM.CardDeck = cards;
            gameVM.Player = _mapp.MapPlayer(_playerLogic.Get(playerId), _playerPropertiesLogic.GetWithPlayerAndRoundId(playerId, roundId)); 
            gameVM.Dealer = _mapp.MapPlayer(_playerLogic.GetQuantityWithRole(1, 1).SingleOrDefault(), _playerPropertiesLogic.GetWithPlayerAndRoundId(_playerLogic.GetQuantityWithRole(1,1).SingleOrDefault().Id, roundId));
            gameVM.Bots = Bots;
                 
            return gameVM;
        }

        //public ViewModels.ResponseModel.ResponseGameProcessGameView NewRound(ViewModels.RequestModel.RequestGameProcessGameView)
        //{


        //    return result;
        //}


        public void SaveChanges(ViewModels.RequestModel.RequestGameProcessGameView item)
        {
            Round round = _roundLogic.Get(item.Round.Id);
            round.Winner = item.Round.Winner;
            round.WinnerScore = item.Round.WinnerScore;

            _roundLogic.Update(round);



            PlayerProperties playerProperties = _playerPropertiesLogic.GetWithPlayerAndRoundId(item.Player.Id, item.Round.Id);
            playerProperties.Score = item.Player.Properties.FirstOrDefault().Score;
            playerProperties.Hand = ReturnHand(item.Player.Properties.SingleOrDefault().Hand);
            _playerPropertiesLogic.Update(playerProperties);

            PlayerProperties dealerProperties = _playerPropertiesLogic.GetWithPlayerAndRoundId(item.Dealer.Id, item.Round.Id);
            dealerProperties.Score = item.Dealer.Properties.FirstOrDefault().Score;
            dealerProperties.Hand = ReturnHand(item.Dealer.Properties.FirstOrDefault().Hand);
            _playerPropertiesLogic.Update(dealerProperties);

            List<PlayerProperties> botsProperties = new List<PlayerProperties>();
            List<Player> bots = new List<Player>();
            bots = _playerLogic.GetQuantityWithRole(item.Bots.Count(), 2).ToList();
            for(int i =0;i < bots.Count(); i++)
            {
                botsProperties.Add(_playerPropertiesLogic.GetWithPlayerAndRoundId(bots[i].Id, item.Round.Id));
            }

            for (int i = 0; i < bots.Count(); i++)
            {
                botsProperties[i].Score = item.Bots[i].Properties.FirstOrDefault().Score;
                botsProperties[i].Hand = ReturnHand(item.Bots[i].Properties.FirstOrDefault().Hand);
                _playerPropertiesLogic.Update(botsProperties[i]);
            }
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

        private List<Card> ReturnHand(List<ViewModels.RequestModel.CardGameProcessGameViewItem> item)
        {
            var result = new List<Card>();
            foreach(var a in item)
            {
                Card card = _cardLogic.Find(x => x.Name == a.Name)
                                      .Where(x => x.Suit == a.Suit)
                                      .SingleOrDefault();
                result.Add(card);
            }

            return result;
        } 

        private int CreatePlayerAndReturnId(ViewModels.RequestModel.RequestGameStartOptionsGameView item)
        {
            Player player = new Player()
            {
                Name = item.PlayerName,
                Role = Roles.Player,
            };

            return _playerLogic.CreateAndReturnId(player);
        }

        private int CreateGameAndReturnId(ViewModels.RequestModel.RequestGameStartOptionsGameView item, int playerId)
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


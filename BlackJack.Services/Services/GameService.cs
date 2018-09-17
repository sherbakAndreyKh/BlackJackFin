using System.Collections.Generic;
using System.Linq;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using BlackJack.Services.Interfaces;
using BlackJack.BusinessLogicLayer.Mapping;

namespace BlackJack.Services.Services
{
    public class GameService : IGameService
    {
        IPlayerLogic _playerLogic;
        IGameLogic _gameLogic;
        IRoundLogic _roundLogic;
        ICardLogic _cardLogic;
        IPlayerRoundHandLogic _playerRoundHandLogic;
        GameServiceResponseMappProvider _mapp;

        public GameService(IPlayerLogic playerLogic, IGameLogic gameLogic, IRoundLogic roundLogic, ICardLogic cardLogic, IPlayerRoundHandLogic playerRoundHandLogic, GameServiceResponseMappProvider mapp)
        {
            _playerLogic = playerLogic;
            _gameLogic = gameLogic;
            _roundLogic = roundLogic;
            _cardLogic = cardLogic;
            _playerRoundHandLogic = playerRoundHandLogic;
            _mapp = mapp;
        }

        public ViewModels.ResponseModel.ResponseGameProcessGameView StartGame(ViewModels.RequestModel.RequestGameStartOptionsGameView item)
        {
            // add Player 
            int playerId = CheckPLayerName(item.PlayerName) ? CreatePlayerAndReturnId(item) : _playerLogic.Find(x => x.Name == item.PlayerName).SingleOrDefault().Id;
            // add Game and return Id         
            int gameId = CreateGameAndReturnId(item, playerId);
            // add Round and return Id
            int roundId = CreateRoundAndReturnId(gameId);
            // add cards
            List<ViewModels.ResponseModel.CardGameProcessGameViewItem> cards = _mapp.MapCardsOnCardGameProcessGameViewItem(_cardLogic.GetAll());

            Player Player = _playerLogic.Get(playerId);
            Player Dealer = _playerLogic.GetQuantityWithRole(1, (int)Roles.Dealer).SingleOrDefault();
            List<Player> BotsList = _playerLogic.GetQuantityWithRole(item.AmountBots, (int)Roles.Bot).ToList();

            ////add Plyer Hands
            var playerList = new List<Player>();
            playerList.Add(Player);
            playerList.Add(Dealer);
            playerList.AddRange(BotsList);

            List<PlayerRoundHand> propertiesList = new List<PlayerRoundHand>();
            for (int i = 0; i < playerList.Count(); i++)
            {
                var property = new PlayerRoundHand();
                property.PlayerId = playerList[i].Id;
                property.RoundId = roundId;
                propertiesList.Add(property);
            }
            _playerRoundHandLogic.CreateMany(propertiesList);
            _playerRoundHandLogic.Save();

            // mappin Players
            var BotsViewItemList = new List<ViewModels.ResponseModel.PlayerGameProcessGameViewItem>();
            
            foreach (var player in BotsList)
            {
                BotsViewItemList.Add(_mapp.MapPlayerOnPlayerGameProccessGameViewItem(player, propertiesList.Where(x=>x.PlayerId == player.Id).SingleOrDefault()));
            }

            ViewModels.ResponseModel.ResponseGameProcessGameView gameViewModel = new ViewModels.ResponseModel.ResponseGameProcessGameView();
            gameViewModel.Game = _mapp.MapGameOnGameGameProcessGameViewItem(_gameLogic.Get(gameId));
            gameViewModel.Round = _mapp.MapRoundOnRoundGameProcessGameViewItem(_roundLogic.Get(roundId));
            gameViewModel.CardDeck = cards;
            gameViewModel.Player = _mapp.MapPlayerOnPlayerGameProccessGameViewItem(Player, propertiesList.Where(x=>x.PlayerId== playerId).SingleOrDefault());
            gameViewModel.Dealer = _mapp.MapPlayerOnPlayerGameProccessGameViewItem(Dealer, propertiesList.Where(x=>x.PlayerId==Dealer.Id).SingleOrDefault());
            gameViewModel.Bots = BotsViewItemList;
                 
            return gameViewModel;
        }

        public ViewModels.ResponseModel.ResponseGameProcessGameView NewRound(ViewModels.RequestModel.RequestGameProcessGameView item)
        {   
            int playerId = item.Player.Id;
            int gameId = item.Game.Id;
            int roundId = CreateRoundAndReturnId(gameId);
            List<ViewModels.ResponseModel.CardGameProcessGameViewItem> cards = _mapp.MapCardsOnCardGameProcessGameViewItem(_cardLogic.GetAll());

            Player Player = _playerLogic.Get(item.Player.Id);
            Player Dealer = _playerLogic.Get(item.Dealer.Id);
            List<Player> BotsList = _playerLogic.GetQuantityWithRole(item.Game.AmountPlayers, (int)Roles.Bot).ToList();

            var playerList = new List<Player>();
            playerList.Add(Player);
            playerList.Add(Dealer);
            playerList.AddRange(BotsList);

            List<PlayerRoundHand> propertiesList = new List<PlayerRoundHand>();
            for (int i = 0; i < playerList.Count(); i++)
            {
                var property = new PlayerRoundHand();
                property.PlayerId = playerList[i].Id;
                property.RoundId = roundId;
                propertiesList.Add(property);
            }
            _playerRoundHandLogic.CreateMany(propertiesList);
            _playerRoundHandLogic.Save();

            var BotsViewItemList = new List<ViewModels.ResponseModel.PlayerGameProcessGameViewItem>();
            foreach(var bot in BotsList)
            {
                BotsViewItemList.Add(_mapp.MapPlayerOnPlayerGameProccessGameViewItem(bot,propertiesList.Where(x=>x.PlayerId==bot.Id).SingleOrDefault()));
            }

            var result = new ViewModels.ResponseModel.ResponseGameProcessGameView();
            result.Game = _mapp.MapGameOnGameGameProcessGameViewItem(_gameLogic.Get(gameId));
            result.Round = _mapp.MapRoundOnRoundGameProcessGameViewItem(_roundLogic.Get(roundId));
            result.CardDeck = cards;
            result.Player = _mapp.MapPlayerOnPlayerGameProccessGameViewItem(Player, _playerRoundHandLogic.GetWithPlayerAndRoundId(playerId, roundId));
            result.Dealer = _mapp.MapPlayerOnPlayerGameProccessGameViewItem(Dealer, _playerRoundHandLogic.GetWithPlayerAndRoundId(Dealer.Id, roundId));
            result.Bots = BotsViewItemList;
            return result;
        }

        public void SaveChanges(ViewModels.RequestModel.RequestGameProcessGameView item)
        {
            Round round = _roundLogic.Get(item.Round.Id);
            round.Winner = item.Round.Winner;
            round.WinnerScore = item.Round.WinnerScore;

            _roundLogic.Update(round);

            var playerPropertiesList = _playerRoundHandLogic.Find(x => x.RoundId == item.Round.Id);

            PlayerRoundHand playerProperties = playerPropertiesList.Where(x => x.PlayerId == item.Player.Id).SingleOrDefault();
            playerProperties.Score = item.Player.Properties.SingleOrDefault().Score;
            playerProperties.Hand = ReturnHand(item.Player.Properties.SingleOrDefault().Hand);
            _playerRoundHandLogic.Update(playerProperties);

            PlayerRoundHand dealerProperties = playerPropertiesList.Where(x => x.PlayerId == item.Dealer.Id).SingleOrDefault();
            dealerProperties.Score = item.Dealer.Properties.SingleOrDefault().Score;
            dealerProperties.Hand = ReturnHand(item.Dealer.Properties.SingleOrDefault().Hand);
            _playerRoundHandLogic.Update(dealerProperties);

            var botsProperties = new List<PlayerRoundHand>();
            var bots = new List<Player>();
            bots = _playerLogic.GetQuantityWithRole(item.Bots.Count(), (int)Roles.Bot).ToList();

            for(int i =0;i < bots.Count(); i++)
            {
                botsProperties.Add(playerPropertiesList.Where(x=>x.PlayerId== bots[i].Id).SingleOrDefault());
            }

            for (int i = 0; i < bots.Count(); i++)
            {
                botsProperties[i].Score = item.Bots[i].Properties.SingleOrDefault().Score;
                botsProperties[i].Hand = ReturnHand(item.Bots[i].Properties.SingleOrDefault().Hand);
            }
            _playerRoundHandLogic.UpdateMany(botsProperties);
        } 

        private bool CheckPLayerName(string name)
        {
            if (_playerLogic.Find(x => x.Name == name).SingleOrDefault() != null)
            {
                return false;
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


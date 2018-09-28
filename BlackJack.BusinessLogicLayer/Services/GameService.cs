using System.Collections.Generic;
using System.Linq;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.BusinessLogicLayer.Maping;

namespace BlackJack.BusinessLogicLayer.Services
{
    public class GameService : IGameService
    {
        IPlayerRepository _playerRepository;
        IGameRepository _gameRepository;
        IRoundRepository _roundRepository;
        ICardRepository _cardRepository;
        IPlayerRoundHandRepository _playerRoundHandRepository;
        GameServiceResponseMappProvider _maping;

        public GameService(IPlayerRepository playerRepository,
                              IGameRepository gameRepository,
                              IRoundRepository roundRepository,
                              ICardRepository cardRepository,
                              IPlayerRoundHandRepository playerRoundHandRepository,
                              GameServiceResponseMappProvider maping)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _cardRepository = cardRepository;
            _playerRoundHandRepository = playerRoundHandRepository;
            _maping = maping;
        }

        public ViewModels.ResponseModel.ResponseGameProcessGameView StartGame(ViewModels.RequestModel.RequestGameStartOptionsGameView item)
        {
            // add Player 
            long playerId = CheckPLayerName(item.PlayerName) ? CreatePlayerAndReturnId(item) : _playerRepository.FindPlayerWithPlayerName(item.PlayerName).Id;
            // add Game and return Id         
            long gameId = CreateGameAndReturnId(item, playerId);
            // add Round and return Id
            long roundId = CreateRoundAndReturnId(gameId);
            // add cards
            List<ViewModels.ResponseModel.CardGameProcessGameViewItem> cards = _maping.MapCardsOnCardGameProcessGameViewItem(_cardRepository.GetAll());

            Player Player = _playerRepository.Get(playerId);
            Player Dealer = _playerRepository.GetQuantityWithRole(1, (int)Role.Dealer).SingleOrDefault();
            List<Player> BotsList = _playerRepository.GetQuantityWithRole(item.AmountBots, (int)Role.Bot).ToList();

            ////add Plyer Hands
            var playerList = new List<Player>();
            playerList.Add(Player);
            playerList.Add(Dealer);
            playerList.AddRange(BotsList);

            List<PlayerRoundHand> playerRoundHandList = new List<PlayerRoundHand>();
            for (int i = 0; i < playerList.Count(); i++)
            {
                var playerRoundHand = new PlayerRoundHand();
                playerRoundHand.PlayerId = playerList[i].Id;
                playerRoundHand.RoundId = roundId;
                playerRoundHandList.Add(playerRoundHand);
            }
            _playerRoundHandRepository.CreateMany(playerRoundHandList);

            // mappin Players
            var BotsViewItemList = new List<ViewModels.ResponseModel.PlayerGameProcessGameViewItem>();
            
            foreach (var player in BotsList)
            {
                BotsViewItemList.Add(_maping.MapPlayerOnPlayerGameProccessGameViewItem(player, playerRoundHandList.Where(x=>x.PlayerId == player.Id).SingleOrDefault()));
            }

            ViewModels.ResponseModel.ResponseGameProcessGameView gameViewModel = new ViewModels.ResponseModel.ResponseGameProcessGameView();
            gameViewModel.Game = _maping.MapGameOnGameGameProcessGameViewItem(_gameRepository.Get(gameId));
            gameViewModel.Round = _maping.MapRoundOnRoundGameProcessGameViewItem(_roundRepository.Get(roundId));
            gameViewModel.CardDeck = cards;
            gameViewModel.Player = _maping.MapPlayerOnPlayerGameProccessGameViewItem(Player, playerRoundHandList.Where(x=>x.PlayerId== playerId).SingleOrDefault());
            gameViewModel.Dealer = _maping.MapPlayerOnPlayerGameProccessGameViewItem(Dealer, playerRoundHandList.Where(x=>x.PlayerId==Dealer.Id).SingleOrDefault());
            gameViewModel.Bots = BotsViewItemList;
                 
            return gameViewModel;
        }

        public ViewModels.ResponseModel.ResponseGameProcessGameView NewRound(ViewModels.RequestModel.RequestGameProcessGameView item)
        {   
            long playerId = item.Player.Id;
            long gameId = item.Game.Id;
            long roundId = CreateRoundAndReturnId(gameId);
            List<ViewModels.ResponseModel.CardGameProcessGameViewItem> cards = _maping.MapCardsOnCardGameProcessGameViewItem(_cardRepository.GetAll());

            Player Player = _playerRepository.Get(item.Player.Id);
            Player Dealer = _playerRepository.Get(item.Dealer.Id);
            List<Player> BotsList = _playerRepository.GetQuantityWithRole(item.Game.AmountPlayers, (int)Role.Bot).ToList();

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
            _playerRoundHandRepository.CreateMany(propertiesList);

            var BotsViewItemList = new List<ViewModels.ResponseModel.PlayerGameProcessGameViewItem>();
            foreach(var bot in BotsList)
            {
                BotsViewItemList.Add(_maping.MapPlayerOnPlayerGameProccessGameViewItem(bot,propertiesList.Where(x=>x.PlayerId==bot.Id).SingleOrDefault()));
            }

            var result = new ViewModels.ResponseModel.ResponseGameProcessGameView();
            result.Game = _maping.MapGameOnGameGameProcessGameViewItem(_gameRepository.Get(gameId));
            result.Round = _maping.MapRoundOnRoundGameProcessGameViewItem(_roundRepository.Get(roundId));
            result.CardDeck = cards;
            result.Player = _maping.MapPlayerOnPlayerGameProccessGameViewItem(Player, _playerRoundHandRepository.GetWithPlayerAndRoundId(playerId, roundId));
            result.Dealer = _maping.MapPlayerOnPlayerGameProccessGameViewItem(Dealer, _playerRoundHandRepository.GetWithPlayerAndRoundId(Dealer.Id, roundId));
            result.Bots = BotsViewItemList;
            return result;
        }

        public void SaveChanges(ViewModels.RequestModel.RequestGameProcessGameView item)
        {
            Round round = _roundRepository.Get(item.Round.Id);
            round.Winner = item.Round.Winner;
            round.WinnerScore = item.Round.WinnerScore;

            _roundRepository.Update(round);

            var playerPropertiesList = _playerRoundHandRepository.FindPLayerRoundHandWithRoundId(item.Round.Id);

            PlayerRoundHand playerProperties = playerPropertiesList.Where(x => x.PlayerId == item.Player.Id).SingleOrDefault();
            playerProperties.Score = item.Player.Properties.SingleOrDefault().Score;
            playerProperties.Hand = ReturnHand(item.Player.Properties.SingleOrDefault().Hand);
            _playerRoundHandRepository.Update(playerProperties);

            PlayerRoundHand dealerProperties = playerPropertiesList.Where(x => x.PlayerId == item.Dealer.Id).SingleOrDefault();
            dealerProperties.Score = item.Dealer.Properties.SingleOrDefault().Score;
            dealerProperties.Hand = ReturnHand(item.Dealer.Properties.SingleOrDefault().Hand);
            _playerRoundHandRepository.Update(dealerProperties);

            var botsProperties = new List<PlayerRoundHand>();
            var bots = new List<Player>();
            bots = _playerRepository.GetQuantityWithRole(item.Bots.Count(), (int)Role.Bot).ToList();

            for(int i =0;i < bots.Count(); i++)
            {
                botsProperties.Add(playerPropertiesList.Where(x=>x.PlayerId== bots[i].Id).SingleOrDefault());
            }

            for (int i = 0; i < bots.Count(); i++)
            {
                botsProperties[i].Score = item.Bots[i].Properties.SingleOrDefault().Score;
                botsProperties[i].Hand = ReturnHand(item.Bots[i].Properties.SingleOrDefault().Hand);
            }
            _playerRoundHandRepository.UpdateMany(botsProperties);
        } 

        private bool CheckPLayerName(string name)
        {
            if (_playerRepository.FindPlayerWithPlayerName(name) != null)
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
                Card card = _cardRepository.FindCardWithNameAndSuit(a.Name, a.Suit);
                result.Add(card);
            }

            return result;
        } 

        private long CreatePlayerAndReturnId(ViewModels.RequestModel.RequestGameStartOptionsGameView item)
        {
            Player player = new Player()
            {
                Name = item.PlayerName,
                Role = Role.Player,
            };

            return _playerRepository.CreateAndReturnId(player);
        }

        private long CreateGameAndReturnId(ViewModels.RequestModel.RequestGameStartOptionsGameView item, long playerId)
        {
            Game game = new Game()
            {
                AmountPlayers = item.AmountBots + 1,
                PlayerId = playerId,
                NumberGame = _gameRepository.ReturnNewGameNumber(playerId)
            };
            return _gameRepository.CreateAndReturnId(game);
        }

        private long CreateRoundAndReturnId(long gameId)
        {
            Round round = new Round()
            {
                GameId = gameId,
                NumberRound = (int)_roundRepository.ReturnNewRoundNumber(gameId)
            };

            return _roundRepository.CreateAndReturnId(round);
        }
    }
}


using System.Collections.Generic;
using System.Linq;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using BlackJack.DataAccess.Interfaces;
using BlackJack.BusinessLogic.Maping;
using System;
using BlackJack.ViewModels;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : IGameService
    {
        private IPlayerRepository _playerRepository;
        private IGameRepository _gameRepository;
        private IRoundRepository _roundRepository;
        private ICardRepository _cardRepository;
        private IPlayerRoundHandRepository _playerRoundHandRepository;
        private IPlayerRoundHandCardsRepository _playerRoundHandCardsRepository;
        private GameServiceResponseMapProvider _maping;

        public GameService(IPlayerRepository playerRepository,
                              IGameRepository gameRepository,
                              IRoundRepository roundRepository,
                              ICardRepository cardRepository,
                              IPlayerRoundHandRepository playerRoundHandRepository,
                              IPlayerRoundHandCardsRepository playerRoundHandCardsRepository,
                              GameServiceResponseMapProvider maping)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _cardRepository = cardRepository;
            _playerRoundHandRepository = playerRoundHandRepository;
            _playerRoundHandCardsRepository = playerRoundHandCardsRepository;
            _maping = maping;
        }

        public ViewModels.ResponseModel.ResponseGameProcessGameView StartGame(ViewModels.RequestModel.RequestGameStartOptionsGameView viewModel)
        {
            long playerId = CheckPLayerName(viewModel.PlayerName) ? CreatePlayerAndReturnId(viewModel) : _playerRepository.GetPlayerByPlayerName(viewModel.PlayerName).Id;      
            long gameId = CreateGameAndReturnId(viewModel, playerId);
            long roundId = CreateRoundAndReturnId(gameId);
            Random random = new Random();
            List<Card> cards = _cardRepository.GetAll().OrderBy(x => random.Next()).ToList();
            Player Player = _playerRepository.Get(playerId);
            Player Dealer = _playerRepository.GetQuantityByRole(1, (int)Role.Dealer).FirstOrDefault();
            List<Player> BotsList = _playerRepository.GetQuantityByRole(viewModel.BotsAmount, (int)Role.Bot).ToList();


            var playerList = new List<Player>();
            playerList.Add(Player);
            playerList.Add(Dealer);
            playerList.AddRange(BotsList);

            List<PlayerRoundHand> playerRoundHandList = CreatePlayerRoundHands(playerList, roundId);
            _playerRoundHandRepository.CreateMany(playerRoundHandList);

            var BotsViewItemList = new List<ViewModels.ResponseModel.PlayerGameProcessGameViewItem>();

            foreach (var player in BotsList)
            {
                BotsViewItemList.Add(_maping.MapPlayerToPlayerGameProccessGameViewItem(player, playerRoundHandList.Where(x => x.PlayerId == player.Id).FirstOrDefault()));
            }

            var gameViewModel = new ViewModels.ResponseModel.ResponseGameProcessGameView();
            gameViewModel.Game = _maping.MapGameToGameGameProcessGameViewItem(_gameRepository.Get(gameId));
            gameViewModel.Round = _maping.MapRoundToRoundGameProcessGameViewItem(_roundRepository.Get(roundId));
            gameViewModel.CardDeck = _maping.MapCardsToCardGameProcessGameViewItem(cards); 
            gameViewModel.Player = _maping.MapPlayerToPlayerGameProccessGameViewItem(Player, playerRoundHandList.Where(x => x.PlayerId == playerId).FirstOrDefault());
            gameViewModel.Dealer = _maping.MapPlayerToPlayerGameProccessGameViewItem(Dealer, playerRoundHandList.Where(x => x.PlayerId == Dealer.Id).FirstOrDefault());
            gameViewModel.Bots = BotsViewItemList;

            return gameViewModel;
        }

        public NewRoundGameView NewRound(ViewModels.RequestModel.RequestGameProcessGameView viewModel)
        {
            long playerId = viewModel.Player.Id;
            long gameId = viewModel.Game.Id;
            long roundId = CreateRoundAndReturnId(gameId);
            Random random = new Random();
            List<Card> cards = _cardRepository.GetAll().OrderBy(x => random.Next()).ToList();
            Player Player = _playerRepository.Get(viewModel.Player.Id);
            Player Dealer = _playerRepository.Get(viewModel.Dealer.Id);
            List<Player> BotsList = _playerRepository.GetQuantityByRole(viewModel.Game.PlayersAmount -1, (int)Role.Bot).ToList();


            var playerList = new List<Player>();
            playerList.Add(Player);
            playerList.Add(Dealer);
            playerList.AddRange(BotsList);

            List<PlayerRoundHand> playerRoundHandList = CreatePlayerRoundHands(playerList, roundId);
            _playerRoundHandRepository.CreateMany(playerRoundHandList);


            var result = new NewRoundGameView();
            result.Game = _maping.MapGameToGameNewRoundGameViewItem(_gameRepository.Get(gameId));
            result.Round = _maping.MapRoundToRoundNewRoundGameViewItem(_roundRepository.Get(roundId));
            result.CardDeck = _maping.MapCardsToCardNewRoundGameViewItem(cards);
            result.Player = _maping.MapPlayerToPlayerNewRoundGameViewItem(Player, _playerRoundHandRepository.GetPlayerRoundHandByPlayerAndRoundId(playerId, roundId));
            result.Dealer = _maping.MapPlayerToPlayerNewRoundGameViewItem(Dealer, _playerRoundHandRepository.GetPlayerRoundHandByPlayerAndRoundId(Dealer.Id, roundId));
            result.Bots = _maping.MapPlayersToPlayerNewRoundGameViewItem(BotsList, playerRoundHandList);
            return result;
        }

        public void SaveChanges(ViewModels.RequestModel.RequestGameProcessGameView viewModel)
        {
            Round round = _roundRepository.Get(viewModel.Round.Id);
            round.Winner = viewModel.Round.Winner;
            round.WinnerScore = viewModel.Round.WinnerScore;

            _roundRepository.Update(round);

            var playerPlayerRoundHandsList = _playerRoundHandRepository.GetPLayerRoundHandListByRoundId(viewModel.Round.Id);

            PlayerRoundHand playerProperties = playerPlayerRoundHandsList.Where(x => x.PlayerId == viewModel.Player.Id).FirstOrDefault();
            playerProperties.Score = viewModel.Player.PlayerRoundHand.FirstOrDefault().Score;
            SaveHands(viewModel.Player.PlayerRoundHand.FirstOrDefault().Hand, playerProperties.Id);
            _playerRoundHandRepository.Update(playerProperties);

            PlayerRoundHand dealerProperties = playerPlayerRoundHandsList.Where(x => x.PlayerId == viewModel.Dealer.Id).FirstOrDefault();
            dealerProperties.Score = viewModel.Dealer.PlayerRoundHand.FirstOrDefault().Score;
            SaveHands(viewModel.Dealer.PlayerRoundHand.FirstOrDefault().Hand, dealerProperties.Id);
            _playerRoundHandRepository.Update(dealerProperties); 

            var botsProperties = new List<PlayerRoundHand>();
            var bots = new List<Player>();
            bots = _playerRepository.GetQuantityByRole(viewModel.Bots.Count(), (int)Role.Bot).ToList();

            for (int i = 0; i < bots.Count(); i++)
            {
                botsProperties.Add(playerPlayerRoundHandsList.Where(x => x.PlayerId == bots[i].Id).FirstOrDefault());
            }

            for (int i = 0; i < bots.Count(); i++)
            {
                botsProperties[i].Score = viewModel.Bots[i].PlayerRoundHand.FirstOrDefault().Score;
                SaveHands(viewModel.Bots[i].PlayerRoundHand.FirstOrDefault().Hand, playerPlayerRoundHandsList.Where(x => x.PlayerId == viewModel.Bots[i].Id).FirstOrDefault().Id);
            }
            _playerRoundHandRepository.UpdateMany(botsProperties);
        }

        private List<PlayerRoundHand> CreatePlayerRoundHands(List<Player> playersList, long roundId)
        {
            List<PlayerRoundHand> result = new List<PlayerRoundHand>();
            for (int i = 0; i < playersList.Count(); i++)
            {
                var playerRoundHand = new PlayerRoundHand();
                playerRoundHand.PlayerId = playersList[i].Id;
                playerRoundHand.RoundId = roundId;
                result.Add(playerRoundHand);
            }
            return result;
        }

        private void SaveHands(List<ViewModels.RequestModel.CardGameProcessGameViewItem> cardsList, long playeRoundhandId)
        {
            var result = new List<PlayerRoundHandCards>(); 
            foreach(var card in cardsList)
            {
                var model = new PlayerRoundHandCards();
                model.PlayerRoundHandId = playeRoundhandId;
                model.CardId = card.Id;
                result.Add(model);
            }
            _playerRoundHandCardsRepository.CreateMany(result);
        }

        private bool CheckPLayerName(string playerName)
        {
            if (_playerRepository.GetPlayerByPlayerName(playerName) != null)
            {
                return false;
            }

            return true;
        }

        private List<Card> ReturnHand(List<ViewModels.RequestModel.CardGameProcessGameViewItem> cardsViewItemList)
        {
            var result = new List<Card>();
            foreach (var cardViewItem in cardsViewItemList)
            {
                Card card = _cardRepository.FindCardWithNameAndSuit(cardViewItem.Name, cardViewItem.Suit);
                result.Add(card);
            }
            return result;
        }

        private long CreatePlayerAndReturnId(ViewModels.RequestModel.RequestGameStartOptionsGameView playerHistoryViewModel)
        {
            Player player = new Player()
            {
                Name = playerHistoryViewModel.PlayerName,
                Role = Role.Player,
            };
            return _playerRepository.CreateAndReturnId(player);
        }

        private long CreateGameAndReturnId(ViewModels.RequestModel.RequestGameStartOptionsGameView playerHistoryViewModel, long playerId)
        {
            Game game = new Game()
            {
                PlayersAmount = playerHistoryViewModel.BotsAmount + 1,
                PlayerId = playerId,
                GameNumber = _gameRepository.GetNewGameNumber(playerId)
            };
            return _gameRepository.CreateAndReturnId(game);
        }

        private long CreateRoundAndReturnId(long gameId)
        {
            Round round = new Round()
            {
                GameId = gameId,
                RoundNumber = (int)_roundRepository.GetNewRoundNumber(gameId)
            };

            return _roundRepository.CreateAndReturnId(round);
        }
    }
}


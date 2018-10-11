using System.Collections.Generic;
using System.Linq;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using BlackJack.DataAccess.Interfaces;
using BlackJack.BusinessLogic.Maping;
using System;
using BlackJack.ViewModels;
using System.Threading.Tasks;

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

        public async Task<ViewModels.ResponseModel.ResponseGameStartOptionsGameView> GetPlayersStartOptions()
        {

            var result = new ViewModels.ResponseModel.ResponseGameStartOptionsGameView();
            result.Players = _maping.MapPlayerToPlayerGameStartOptionsGameBiewItem(await _playerRepository.GetAllPlayersByRole(Role.Player));
            return result;
        }

        public async Task<ViewModels.ResponseModel.ResponseGameProcessGameView> StartGame(ViewModels.RequestModel.RequestGameStartOptionsGameView viewModel)
        {
            long playerId = await CheckPLayerName(viewModel.PlayerName) ? await CreatePlayerAndReturnId(viewModel) : await _playerRepository.GetPlayerIdByPlayerName(viewModel.PlayerName);
            long gameId = await CreateGameAndReturnId(viewModel, playerId);
            long roundId = await CreateRoundAndReturnId(gameId);
            Random random = new Random();
            List<Card> cards = await _cardRepository.GetAll();
          
            Player player = await _playerRepository.Get(playerId);
            Player dealer = await _playerRepository.GetFirstPlayerByRole(Role.Dealer);
            List<Player> botList = await _playerRepository.GetQuantityByRole(viewModel.BotsAmount, (int)Role.Bot);

            var playerList = new List<Player>();
            playerList.Add(player);
            playerList.Add(dealer);
            playerList.AddRange(botList);

            List<PlayerRoundHand> playerRoundHandList = CreatePlayerRoundHands(playerList, roundId);
            await _playerRoundHandRepository.CreateManyAsync(playerRoundHandList);

            var BotsViewItemList = new List<ViewModels.ResponseModel.PlayerGameProcessGameViewItem>();

            foreach (var bot in botList)
            {
                BotsViewItemList.Add(_maping.MapPlayerToPlayerGameProccessGameViewItem(bot, playerRoundHandList.Where(x => x.PlayerId == bot.Id).FirstOrDefault()));
            }

            var gameViewModel = new ViewModels.ResponseModel.ResponseGameProcessGameView();
            gameViewModel.Game = _maping.MapGameToGameGameProcessGameViewItem(await _gameRepository.Get(gameId));
            gameViewModel.Round = _maping.MapRoundToRoundGameProcessGameViewItem(await _roundRepository.Get(roundId));
            gameViewModel.CardDeck = _maping.MapCardsToCardGameProcessGameViewItem(cards.OrderBy(x => random.Next()));
            gameViewModel.Player = _maping.MapPlayerToPlayerGameProccessGameViewItem(player, playerRoundHandList.Where(x => x.PlayerId == playerId).FirstOrDefault());
            gameViewModel.Dealer = _maping.MapPlayerToPlayerGameProccessGameViewItem(dealer, playerRoundHandList.Where(x => x.PlayerId == dealer.Id).FirstOrDefault());
            gameViewModel.Bots = BotsViewItemList;

            return gameViewModel;
        }

        public async Task<NewRoundGameView> NewRound(ViewModels.RequestModel.RequestGameProcessGameView viewModel)
        {
            long playerId = viewModel.Player.Id;
            long gameId = viewModel.Game.Id;
            long roundId = await CreateRoundAndReturnId(gameId);
            Random random = new Random();
            List<Card> cards = await _cardRepository.GetAll();
           

            Player player = await _playerRepository.Get(viewModel.Player.Id);
            Player dealer = await _playerRepository.Get(viewModel.Dealer.Id);
            List<Player> botList = await _playerRepository.GetQuantityByRole(viewModel.Game.PlayersAmount - 1, (int)Role.Bot);


            var playerList = new List<Player>();
            playerList.Add(player);
            playerList.Add(dealer);
            playerList.AddRange(botList);

            List<PlayerRoundHand> playerRoundHandList = CreatePlayerRoundHands(playerList, roundId);
            await _playerRoundHandRepository.CreateManyAsync(playerRoundHandList);


            var result = new NewRoundGameView();
            result.Game = _maping.MapGameToGameNewRoundGameViewItem(await _gameRepository.Get(gameId));
            result.Round = _maping.MapRoundToRoundNewRoundGameViewItem(await _roundRepository.Get(roundId));
            result.CardDeck = _maping.MapCardsToCardNewRoundGameViewItem(cards.OrderBy(x => random.Next()));
            result.Player = _maping.MapPlayerToPlayerNewRoundGameViewItem(player, await _playerRoundHandRepository.GetPlayerRoundHandByPlayerAndRoundId(playerId, roundId));
            result.Dealer = _maping.MapPlayerToPlayerNewRoundGameViewItem(dealer, await _playerRoundHandRepository.GetPlayerRoundHandByPlayerAndRoundId(dealer.Id, roundId));
            result.Bots = _maping.MapPlayersToPlayerNewRoundGameViewItem(botList, playerRoundHandList);
            return result;
        }

        public async Task SaveChanges(ViewModels.RequestModel.RequestGameProcessGameView viewModel)
        {
            Round round = await _roundRepository.Get(viewModel.Round.Id);
            round.Winner = viewModel.Round.Winner;
            round.WinnerScore = viewModel.Round.WinnerScore;

            await _roundRepository.Update(round);

            List<PlayerRoundHand> playerPlayerRoundHandsList = await _playerRoundHandRepository.GetPLayerRoundHandListByRoundId(viewModel.Round.Id);

            PlayerRoundHand playerProperties = playerPlayerRoundHandsList.Where(x => x.PlayerId == viewModel.Player.Id).FirstOrDefault();
            playerProperties.Score = viewModel.Player.PlayerRoundHand.FirstOrDefault().Score;
            await SaveHands(viewModel.Player.PlayerRoundHand.FirstOrDefault().Hand, playerProperties.Id);
            await _playerRoundHandRepository.Update(playerProperties);

            PlayerRoundHand dealerProperties = playerPlayerRoundHandsList.Where(x => x.PlayerId == viewModel.Dealer.Id).FirstOrDefault();
            dealerProperties.Score = viewModel.Dealer.PlayerRoundHand.FirstOrDefault().Score;
            await SaveHands(viewModel.Dealer.PlayerRoundHand.FirstOrDefault().Hand, dealerProperties.Id);
            await _playerRoundHandRepository.Update(dealerProperties);

            var botsProperties = new List<PlayerRoundHand>();
            var bots = new List<Player>();
            bots = await _playerRepository.GetQuantityByRole(viewModel.Bots.Count(), (int)Role.Bot);

            for (int i = 0; i < bots.Count(); i++)
            {
                botsProperties.Add(playerPlayerRoundHandsList.Where(x => x.PlayerId == bots[i].Id).FirstOrDefault());
            }

            for (int i = 0; i < bots.Count(); i++)
            {
                botsProperties[i].Score = viewModel.Bots[i].PlayerRoundHand.FirstOrDefault().Score;
                await SaveHands(viewModel.Bots[i].PlayerRoundHand.FirstOrDefault().Hand, playerPlayerRoundHandsList.Where(x => x.PlayerId == viewModel.Bots[i].Id).FirstOrDefault().Id);
            }
            await _playerRoundHandRepository.UpdateManyAsync(botsProperties);
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

        private async Task SaveHands(List<ViewModels.RequestModel.CardGameProcessGameViewItem> cardsList, long playeRoundhandId)
        {
            var result = new List<PlayerRoundHandCards>();
            foreach (var card in cardsList)
            {
                var model = new PlayerRoundHandCards();
                model.PlayerRoundHandId = playeRoundhandId;
                model.CardId = card.Id;
                result.Add(model);
            }
            await _playerRoundHandCardsRepository.CreateManyAsync(result);
        }

        private async Task<bool> CheckPLayerName(string playerName)
        {
            if (await _playerRepository.GetPlayerByPlayerName(playerName) != null)
            {
                return false;
            }

            return true;
        }

        private async Task<List<Card>> ReturnHand(List<ViewModels.RequestModel.CardGameProcessGameViewItem> cardsViewItemList)
        {
            var result = new List<Card>();
            foreach (var cardViewItem in cardsViewItemList)
            {
                Card card = await _cardRepository.FindCardWithNameAndSuit(cardViewItem.Name, cardViewItem.Suit);
                result.Add(card);
            }
            return result;
        }

        private async Task<long> CreatePlayerAndReturnId(ViewModels.RequestModel.RequestGameStartOptionsGameView playerHistoryViewModel)
        {
            Player player = new Player();
            player.Name = playerHistoryViewModel.PlayerName;
            player.Role = Role.Player;
            long Id = await _playerRepository.CreateAndReturnId(player);
            return Id;
        }

        private async Task<long> CreateGameAndReturnId(ViewModels.RequestModel.RequestGameStartOptionsGameView playerHistoryViewModel, long playerId)
        {
            Game game = new Game();
            game.PlayerId = playerId;
            game.PlayersAmount = playerHistoryViewModel.BotsAmount + 1;
            game.GameNumber = await _gameRepository.GetNewGameNumber(playerId);
            long Id = await _gameRepository.CreateAndReturnId(game);
            return Id;
        }

        private async Task<long> CreateRoundAndReturnId(long gameId)
        {
            Round round = new Round();
            round.GameId = gameId;
            round.RoundNumber = await _roundRepository.GetNewRoundNumber(gameId);
            long Id = await _roundRepository.CreateAndReturnId(round);
            return Id;
        }
    }
}


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
using BlackJack.ViewModels.RequestModel;
using BlackJack.ViewModels.ResponseModel;
using BlackJack.BusinessLogic.Exceptions;

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
        private GameServiceMapProvider _maping;

        public GameService(IPlayerRepository playerRepository,
                              IGameRepository gameRepository,
                              IRoundRepository roundRepository,
                              ICardRepository cardRepository,
                              IPlayerRoundHandRepository playerRoundHandRepository,
                              IPlayerRoundHandCardsRepository playerRoundHandCardsRepository,
                              GameServiceMapProvider maping)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _cardRepository = cardRepository;
            _playerRoundHandRepository = playerRoundHandRepository;
            _playerRoundHandCardsRepository = playerRoundHandCardsRepository;
            _maping = maping;
        }

        public async Task<ResponseGameStartOptionsGameView> GetPlayersStartOptions()
        {
            var result = new ResponseGameStartOptionsGameView();
            result.Players = _maping.MapPlayerToPlayerGameStartOptionsGameBiewItem(await _playerRepository.GetAllPlayersByRole(Role.Player));
            return result;
        }

        public async Task<ResponseGameProcessGameView> StartGame(RequestGameStartOptionsGameView viewModel)
        {
            long playerId = await CheckPLayerName(viewModel.PlayerName) ? await CreatePlayerAndReturnId(viewModel) : await _playerRepository.GetPlayerIdByPlayerName(viewModel.PlayerName);
            long gameId = await CreateGameAndReturnId(viewModel, playerId);
            long roundId = await CreateRoundAndReturnId(gameId);

            Player player = await _playerRepository.Get(playerId);
            Player dealer = await _playerRepository.GetFirstPlayerByRole(Role.Dealer);
            List<Player> botList = await _playerRepository.GetQuantityByRole(viewModel.BotsAmount, (int)Role.Bot);

            var playerList = new List<Player>();
            playerList.Add(player);
            playerList.AddRange(botList);
            playerList.Add(dealer);

            List<PlayerRoundHand> playerRoundHandList = CreatePlayerRoundHands(playerList, roundId);
            await _playerRoundHandRepository.CreateManyAsync(playerRoundHandList);
            playerRoundHandList = await _playerRoundHandRepository.GetPLayerRoundHandListByRoundId(roundId);

            var gameViewModel = new ResponseGameProcessGameView();
            gameViewModel.Game = _maping.MapGameToGameGameProcessGameViewItem(await _gameRepository.Get(gameId));
            gameViewModel.Round = _maping.MapRoundToRoundGameProcessGameViewItem(await _roundRepository.Get(roundId));
            gameViewModel.Player = _maping.MapPlayerToPlayerGameProccessGameViewItem(playerList.Where(x => x.Role == Role.Player).FirstOrDefault(), playerRoundHandList);
            gameViewModel.Dealer = _maping.MapPlayerToPlayerGameProccessGameViewItem(playerList.Where(x => x.Role == Role.Dealer).FirstOrDefault(), playerRoundHandList);
            gameViewModel.Bots = _maping.MapPlayerListToPlayerGameProccessGameViewItem(playerList.Where(x => x.Role == Role.Bot).ToList(), playerRoundHandList);
            return gameViewModel;
        }

        public async Task<ResponseNewRoundGameView> NewRound(RequestNewRoundGameView item)
        {
            long roundId = await CreateRoundAndReturnId(item.Game.Id);
            var playerList = new List<ViewModels.RequestModel.PlayerNewRoundGameViewItem>();
            playerList.Add(item.Player);
            playerList.AddRange(item.Bots);
            playerList.Add(item.Dealer);

            List<PlayerRoundHand> playerRoundHandList = CreatePlayerRoundHands(playerList, roundId);
            await _playerRoundHandRepository.CreateManyAsync(playerRoundHandList);
            playerRoundHandList = await _playerRoundHandRepository.GetPLayerRoundHandListByRoundId(roundId);

            var result = new ResponseNewRoundGameView();
            result.Game = _maping.MapGameToGameNewRoundGameViewItem(item.Game);
            result.Round = _maping.MapRoundToRoundNewRoundGameViewItem(await _roundRepository.Get(roundId));
            result.Player = _maping.MapPlayerToPlayerNewRoundGameViewItem(playerList
                .Where(x => x.Role == (int)Role.Player)
                .FirstOrDefault(),
                playerRoundHandList.Where(x => x.PlayerId == item.Player.Id)
                .SingleOrDefault());
            result.Dealer = _maping.MapPlayerToPlayerNewRoundGameViewItem(playerList.Where(x => x.Role == (int)Role.Dealer).FirstOrDefault(), playerRoundHandList.Where(x => x.PlayerId == item.Dealer.Id).SingleOrDefault());
            result.Bots = _maping.MapPlayerListToPlayerNewRoundGameViewItem(playerList.Where(x => x.Role == (int)Role.Bot).ToList(), playerRoundHandList);
            return result;
        }

        public async Task<ResponseGetFirstDealGameView> GetFirstDeal(RequestGetFirstDealGameView model)
        {
            List<Card> cards = await _cardRepository.GetAll();
            Random random = new Random((int)DateTime.Now.Ticks);
            Stack<Card> mixCards = new Stack<Card>(cards.OrderBy(x => random.Next()));
            List<PlayerRoundHand> playerRoundHands = await _playerRoundHandRepository.GetPLayerRoundHandListByRoundId(model.Round.Id);

            foreach (var hand in playerRoundHands)
            {
                var cardHand = new List<Card>();
                cardHand.Add(GetCard(mixCards));
                cardHand.Add(GetCard(mixCards));
                hand.Score = cardHand.First().Value + cardHand.Last().Value;
                await SaveHands(cardHand, hand.Id);
            }
            await _playerRoundHandRepository.UpdateManyAsync(playerRoundHands);

            var result = new ResponseGetFirstDealGameView();
            result.Hands = _maping.MapPlayerRouondHandGetFirstDealGameViewItem(playerRoundHands, await _cardRepository.GetPlayerRoundHandCards(model.Round.Id));
            return result;
        }

        public async Task<ResponseGetCardGameView> GetCard(RequestGetCardGameView model)
        {
            var result = new ResponseGetCardGameView();
            if (!(await HandValidation(model.Hand.PlayerId)))
            {
                throw new WrongDataException("Your Data is incorrect");
            }

            List<Card> cards = await _cardRepository.GetAll();
            Random random = new Random((int)DateTime.Now.Ticks);
            Stack<Card> mixCards = new Stack<Card>(cards.OrderBy(x => random.Next()));
            PlayerRoundHand playerRoundHand = await _playerRoundHandRepository.GetPlayerRoundHandByPlayerAndRoundId(model.Hand.PlayerId, model.Round.Id);
            Card card = GetCard(mixCards);
            playerRoundHand.Score += card.Value;
            await SaveHands(card, playerRoundHand.Id);
            await _playerRoundHandRepository.Update(playerRoundHand);

            result.Hand = _maping.MapPlayerRoundHandToPlayerRoundHandGetCardGameViewItem(playerRoundHand, await _cardRepository.GetPlayerRoundHandCards(model.Round.Id));
            return result;
        }

        public async Task<ResponseBotLogicGameView> BotLogic(RequestBotLogicGameView model)
        {

            List<Card> cards = await _cardRepository.GetAll();
            Random random = new Random((int)DateTime.Now.Ticks);
            PlayerRoundHand playerRoundHand = await _playerRoundHandRepository.GetPlayerRoundHandByPlayerAndRoundId(model.Hand.PlayerId, model.Round.Id);

            while (playerRoundHand.Score < 17)
            {
                Stack<Card> mixCards = new Stack<Card>(cards.OrderBy(x => random.Next()));
                Card card = GetCard(mixCards);
                playerRoundHand.Score += card.Value;
                await SaveHands(card, playerRoundHand.Id);
            }
            await _playerRoundHandRepository.Update(playerRoundHand);

            var result = new ResponseBotLogicGameView();
            result.Hand = _maping.MapPlayerRoundHandToPlayerRoundHandBotLogicGameViewItem(playerRoundHand, await _cardRepository.GetPlayerRoundHandCards(model.Round.Id));
            return result;
        }

        public async Task<ResponseFindWinnerGameView> FindWinner(RequestFindWinnerGameView item)
        {
            int score = 21;
            Player player = await _playerRepository.Get(item.PlayerHand.PlayerId);
            Player dealer = await _playerRepository.Get(item.DealerHand.PlayerId);
            PlayerRoundHand playerHand = await _playerRoundHandRepository.Get(item.PlayerHand.Id);
            PlayerRoundHand dealerHand = await _playerRoundHandRepository.Get(item.DealerHand.Id);
            Round round = await _roundRepository.Get(playerHand.RoundId);

            if (playerHand.Score > score && dealerHand.Score <= score)
            {
                round.Winner = dealer.Name;
                round.WinnerScore = dealerHand.Score;
            }
            if (dealerHand.Score <= score && dealerHand.Score > playerHand.Score)
            {
                round.Winner = dealer.Name;
                round.WinnerScore = dealerHand.Score;
            }
            if (dealerHand.Score > score && playerHand.Score > score)
            {
                round.Winner = "Draw";
                round.WinnerScore = 0;
            }
            if (dealerHand.Score == playerHand.Score)
            {
                round.Winner = "Draw";
                round.WinnerScore = 0;
            }
            if (dealerHand.Score > score && playerHand.Score <= score)
            {
                round.Winner = player.Name;
                round.WinnerScore = playerHand.Score;
            }
            if (playerHand.Score <= score && playerHand.Score > dealerHand.Score)
            {
                round.Winner = player.Name;
                round.WinnerScore = playerHand.Score;
            }
            await _roundRepository.Update(round);

            var result = new ResponseFindWinnerGameView();
            result.Round = _maping.MapRoundToRoundFindWinnerGameViewItem(round);
            return result;
        }

        private async Task<bool> HandValidation(long playerId)
        {
            Player player = await _playerRepository.Get(playerId);
            if (player.Role == Role.Player )
            {
                return true;
            }
            return false;
        }

        private async Task<bool> CheckPLayerName(string playerName)
        {
            if (await _playerRepository.GetPlayerByPlayerName(playerName) != null)
            {
                return false;
            }

            return true;
        }

        private Card GetCard(Stack<Card> cards)
        {
            var result = new Card();
            result = cards.Pop();
            return result;
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

        private List<PlayerRoundHand> CreatePlayerRoundHands(List<ViewModels.RequestModel.PlayerNewRoundGameViewItem> playersList, long roundId)
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

        private async Task SaveHands(List<Card> cardsList, long playeRoundhandId)
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

        private async Task SaveHands(Card card, long playerRoundHandId)
        {
            var result = new PlayerRoundHandCards();
            result.PlayerRoundHandId = playerRoundHandId;
            result.CardId = card.Id;
            await _playerRoundHandCardsRepository.Create(result);
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

        private async Task<long> CreatePlayerAndReturnId(RequestGameStartOptionsGameView playerHistoryViewModel)
        {
            Player player = new Player();
            player.Name = playerHistoryViewModel.PlayerName;
            player.Role = Role.Player;
            long Id = await _playerRepository.CreateAndReturnId(player);
            return Id;
        }

        private async Task<long> CreateGameAndReturnId(RequestGameStartOptionsGameView playerHistoryViewModel, long playerId)
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


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

            var gameViewModel = new ResponseGameProcessGameView();
            gameViewModel.Game = _maping.MapGameToGameGameProcessGameViewItem(await _gameRepository.Get(gameId));
            gameViewModel.Round = _maping.MapRoundToRoundGameProcessGameViewItem(await _roundRepository.Get(roundId));
            gameViewModel.Player = _maping.MapPlayerToPlayerGameProccessGameViewItem(playerList.Where(x => x.Role == Role.Player).FirstOrDefault(), playerRoundHandList);
            gameViewModel.Dealer = _maping.MapPlayerToPlayerGameProccessGameViewItem(playerList.Where(x => x.Role == Role.Dealer).FirstOrDefault(), playerRoundHandList);
            gameViewModel.Bots = _maping.MapPlayerListToPlayerGameProccessGameViewItem(playerList.Where(x=>x.Role == Role.Bot).ToList(), playerRoundHandList);
            return gameViewModel;
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
            return  result;
        }

        public async Task<ResponseGetCardGameView> GetCard(RequestGetCardGameView model)
        {
            List<Card> cards = await _cardRepository.GetAll();
            Random random = new Random((int)DateTime.Now.Ticks);
            Stack<Card> mixCards = new Stack<Card>(cards.OrderBy(x => random.Next()));
            PlayerRoundHand playerRoundHand = await _playerRoundHandRepository.GetPlayerRoundHandByPlayerAndRoundId(model.Hand.PlayerId, model.Round.Id);
            Card card = GetCard(mixCards);
            playerRoundHand.Score += card.Value;
            await SaveHands(card, playerRoundHand.Id);
            await _playerRoundHandRepository.Update(playerRoundHand);

            var result = new ResponseGetCardGameView();
            result.Hand = _maping.MapPlayerRoundHandToPlayerRoundHandGetCardGameViewItem(playerRoundHand, await _cardRepository.GetPlayerRoundHandCards(model.Round.Id));
            return result;
        }

        public async Task<ResponseBotLogicGameView> BotLogic (RequestBotLogicGameView model)
        {
            List<Card> cards = await _cardRepository.GetAll();
            Random random = new Random((int)DateTime.Now.Ticks);
            PlayerRoundHand playerRoundHand = await _playerRoundHandRepository.GetPlayerRoundHandByPlayerAndRoundId(model.Hand.PlayerId, model.Round.Id);
            
            while (playerRoundHand.Score < 17)
            {
            Stack<Card> mixCards = new Stack<Card>(cards.OrderBy(x=>random.Next()));
                Card card = GetCard(mixCards);
                playerRoundHand.Score += card.Value;
                await SaveHands(card, playerRoundHand.Id);    
            }
            await _playerRoundHandRepository.Update(playerRoundHand);

            var result = new ResponseBotLogicGameView();
            result.Hand = _maping.MapPlayerRoundHandToPlayerRoundHandBotLogicGameViewItem(playerRoundHand, await _cardRepository.GetPlayerRoundHandCards(model.Round.Id));
            return result;
        }

        //public async Task<NewRoundGameView> NewRound(RequestGameProcessGameView viewModel)
        //{
        //    long playerId = viewModel.Player.Id;
        //    long gameId = viewModel.Game.Id;
        //    long roundId = await CreateRoundAndReturnId(gameId);
        //    Random random = new Random((int)DateTime.Now.Ticks);
        //    List<Card> cards = await _cardRepository.GetAll();

        //    Player player = await _playerRepository.Get(viewModel.Player.Id);
        //    Player dealer = await _playerRepository.Get(viewModel.Dealer.Id);
        //    List<Player> botList = await _playerRepository.GetQuantityByRole(viewModel.Game.PlayersAmount - 1, (int)Role.Bot);

        //    var playerList = new List<Player>();
        //    playerList.Add(player);
        //    playerList.Add(dealer);
        //    playerList.AddRange(botList);

        //    List<PlayerRoundHand> playerRoundHandList = CreatePlayerRoundHands(playerList, roundId);
        //    await _playerRoundHandRepository.CreateManyAsync(playerRoundHandList);

        //    var result = new NewRoundGameView();
        //    result.Game = _maping.MapGameToGameNewRoundGameViewItem(await _gameRepository.Get(gameId));
        //    result.Round = _maping.MapRoundToRoundNewRoundGameViewItem(await _roundRepository.Get(roundId));
        //    result.CardDeck = _maping.MapCardsToCardNewRoundGameViewItem(cards.OrderBy(x => random.Next()));
        //    result.Player = _maping.MapPlayerToPlayerNewRoundGameViewItem(player, await _playerRoundHandRepository.GetPlayerRoundHandByPlayerAndRoundId(playerId, roundId));
        //    result.Dealer = _maping.MapPlayerToPlayerNewRoundGameViewItem(dealer, await _playerRoundHandRepository.GetPlayerRoundHandByPlayerAndRoundId(dealer.Id, roundId));
        //    result.Bots = _maping.MapPlayersToPlayerNewRoundGameViewItem(botList, playerRoundHandList);
        //    return result;
        //}

        //public async Task SaveChanges(RequestGameProcessGameView viewModel)
        //{
        //    Round round = await _roundRepository.Get(viewModel.Round.Id);
        //    round.Winner = viewModel.Round.Winner;
        //    round.WinnerScore = viewModel.Round.WinnerScore;

        //    await _roundRepository.Update(round);

        //    List<PlayerRoundHand> playerPlayerRoundHandsList = await _playerRoundHandRepository.GetPLayerRoundHandListByRoundId(viewModel.Round.Id);

        //    PlayerRoundHand playerProperties = playerPlayerRoundHandsList.Where(x => x.PlayerId == viewModel.Player.Id).FirstOrDefault();
        //    playerProperties.Score = viewModel.Player.PlayerRoundHand.FirstOrDefault().Score;
        //    //await SaveHands(viewModel.Player.PlayerRoundHand.FirstOrDefault().Hand, playerProperties.Id);
        //    await _playerRoundHandRepository.Update(playerProperties);

        //    PlayerRoundHand dealerProperties = playerPlayerRoundHandsList.Where(x => x.PlayerId == viewModel.Dealer.Id).FirstOrDefault();
        //    dealerProperties.Score = viewModel.Dealer.PlayerRoundHand.FirstOrDefault().Score;
        //    //await SaveHands(viewModel.Dealer.PlayerRoundHand.FirstOrDefault().Hand, dealerProperties.Id);
        //    await _playerRoundHandRepository.Update(dealerProperties);

        //    var botsProperties = new List<PlayerRoundHand>();
        //    var bots = new List<Player>();
        //    bots = await _playerRepository.GetQuantityByRole(viewModel.Bots.Count(), (int)Role.Bot);

        //    for (int i = 0; i < bots.Count(); i++)
        //    {
        //        botsProperties.Add(playerPlayerRoundHandsList.Where(x => x.PlayerId == bots[i].Id).FirstOrDefault());
        //    }

        //    for (int i = 0; i < bots.Count(); i++)
        //    {
        //        botsProperties[i].Score = viewModel.Bots[i].PlayerRoundHand.FirstOrDefault().Score;
        //        //await SaveHands(viewModel.Bots[i].PlayerRoundHand.FirstOrDefault().Hand, playerPlayerRoundHandsList.Where(x => x.PlayerId == viewModel.Bots[i].Id).FirstOrDefault().Id);
        //    }
        //    await _playerRoundHandRepository.UpdateManyAsync(botsProperties);
        //}


        private async Task<Round> FindWinner(PlayerRoundHand playerHand, PlayerRoundHand dealerHand)
        {
            Round round = await _roundRepository.Get(playerHand.RoundId);
            Player player = await _playerRepository.Get(playerHand.PlayerId);
            Player dealer = await _playerRepository.Get(dealerHand.PlayerId);

            if (playerHand.Score > 21 && dealerHand.Score < 21)
            {
                round.Winner = dealer.Name;
                round.WinnerScore = dealerHand.Score;
            }
            if (dealerHand.Score <= 21 && dealerHand.Score > playerHand.Score)
            {
                round.Winner = dealer.Name;
                round.WinnerScore = dealerHand.Score;
            }
            if (dealerHand.Score > 21 && playerHand.Score > 21)
            {
                round.Winner = "Draw";
                round.WinnerScore = 0;
            }
            if (dealerHand.Score == playerHand.Score)
            {
                round.Winner = "Draw";
                round.WinnerScore = 0;
            }
            if (dealerHand.Score > 21 && playerHand.Score < 21)
            {
                round.Winner = player.Name;
                round.WinnerScore = playerHand.Score;
            }
            if (playerHand.Score <= 21 && playerHand.Score > dealerHand.Score)
            {
                round.Winner = player.Name;
                round.WinnerScore = playerHand.Score;
            }
            return round;
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


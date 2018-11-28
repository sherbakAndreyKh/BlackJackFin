using BlackJack.Entities;
using BlackJack.ViewModels;
using System.Collections.Generic;
using BlackJack.ViewModels.ResponseModel;
using System.Linq;

namespace BlackJack.BusinessLogic.Maping
{
    public class GameServiceMapProvider
    {
        public List<PlayerGameStartOptionsGameViewItem> MapPlayerToPlayerGameStartOptionsGameBiewItem(List<Player> players)
        {
            var result = new List<PlayerGameStartOptionsGameViewItem>();
            foreach (var player in players)
            {
                var ViewModel = new PlayerGameStartOptionsGameViewItem();
                ViewModel.PlayerName = player.Name;
                result.Add(ViewModel);
            }
            return result;
        }

        public PlayerGameProcessGameViewItem MapPlayerToPlayerGameProccessGameViewItem(Player player, List<PlayerRoundHand> playerRoundHands)
        {
            var result = new PlayerGameProcessGameViewItem();
            result.Id = player.Id;
            result.Name = player.Name;
            result.Role = (int)player.Role;
            result.PlayerRoundHand = MapRoundHandToPlayerRoundHandGameProcessGameViewItem(playerRoundHands.Where(x => x.PlayerId == player.Id).FirstOrDefault());
            return result;
        }

        public List<PlayerGameProcessGameViewItem> MapPlayerListToPlayerGameProccessGameViewItem(List<Player> players, List<PlayerRoundHand> playerRoundHands)
        {
            var result = new List<PlayerGameProcessGameViewItem>();

            foreach (var player in players)
            {
                var viewModel = new PlayerGameProcessGameViewItem();
                viewModel.Id = player.Id;
                viewModel.Name = player.Name;
                viewModel.Role = (int)player.Role;
                viewModel.PlayerRoundHand = MapRoundHandToPlayerRoundHandGameProcessGameViewItem(playerRoundHands.Where(x => x.PlayerId == player.Id).FirstOrDefault());
                result.Add(viewModel);
            }

            return result;
        }

        public PlayerRoundHandGameProcessGameViewItem MapRoundHandToPlayerRoundHandGameProcessGameViewItem(PlayerRoundHand playerRoundhands)
        {
            var result = new PlayerRoundHandGameProcessGameViewItem();
            result.Id = playerRoundhands.Id;
            result.PlayerId = playerRoundhands.PlayerId;
            result.RoundId = playerRoundhands.RoundId;
            return result;
        }

        public List<CardGameProcessGameViewItem> MapCardsToCardGameProcessGameViewItem(IEnumerable<Card> cardsList)
        {
            var result = new List<CardGameProcessGameViewItem>();

            foreach (var card in cardsList)
            {
                var CardView = new CardGameProcessGameViewItem();
                CardView.Id = card.Id;
                CardView.Name = card.Name.ToString();
                CardView.Suit = card.Suit.ToString();
                result.Add(CardView);
            }
            return result;
        }

        public GameGameProcessGameViewItem MapGameToGameGameProcessGameViewItem(Game game)
        {
            var result = new GameGameProcessGameViewItem();
            result.Id = game.Id;
            result.GameNumber = game.GameNumber;
            return result;
        }

        public RoundGameProcessGameViewItem MapRoundToRoundGameProcessGameViewItem(Round round)
        {
            var result = new RoundGameProcessGameViewItem();
            result.Id = round.Id;
            result.RoundNumber = round.RoundNumber;
            result.Winner = round.Winner;
            return result;
        }

        public GameNewRoundGameViewItem MapGameToGameNewRoundGameViewItem(ViewModels.RequestModel.GameNewRoundGameViewItem game)
        {
            var result = new GameNewRoundGameViewItem();
            result.Id = game.Id;
            result.GameNumber = game.GameNumber;
            return result;
        }

        public RoundNewRoundGameViewItem MapRoundToRoundNewRoundGameViewItem(Round round)
        {
            var result = new RoundNewRoundGameViewItem();
            result.Id = round.Id;
            result.RoundNumber = round.RoundNumber;
            result.GameId = (int)round.GameId;
            result.Winner = round.Winner;
            result.WinnerScore = round.WinnerScore;
            return result;
        }

        public PlayerNewRoundGameViewItem MapPlayerToPlayerNewRoundGameViewItem(ViewModels.RequestModel.PlayerNewRoundGameViewItem player, PlayerRoundHand playerRoundHand)
        {
            var result = new PlayerNewRoundGameViewItem();
            result.Id = player.Id;
            result.Name = player.Name;
            result.Role = (int)player.Role;
            result.PlayerRoundHand = MapRoundHandToPlayerRoundHandNewRoundGameViewItem(playerRoundHand);
            return result;
        }

        public List<PlayerNewRoundGameViewItem> MapPlayerListToPlayerNewRoundGameViewItem(List<ViewModels.RequestModel.PlayerNewRoundGameViewItem> playerList, List<PlayerRoundHand> playerRoundHandList)
        {
            var result = new List<PlayerNewRoundGameViewItem>();
            foreach (var player in playerList)
            {
                PlayerNewRoundGameViewItem playerViewModel = new PlayerNewRoundGameViewItem();
                playerViewModel.Id = player.Id;
                playerViewModel.Name = player.Name;
                playerViewModel.Role = (int)player.Role;
                playerViewModel.PlayerRoundHand = MapRoundHandToPlayerRoundHandNewRoundGameViewItem(playerRoundHandList.Where(x => x.PlayerId == player.Id).FirstOrDefault());
                result.Add(playerViewModel);
            }
            return result;
        }

        public PlayerRoundHandNewRoundGameViewItem MapRoundHandToPlayerRoundHandNewRoundGameViewItem(PlayerRoundHand playerRoundHand)
        {
            var result = new PlayerRoundHandNewRoundGameViewItem();
            result.Id = playerRoundHand.Id;
            result.PlayerId = playerRoundHand.PlayerId;
            result.RoundId = (int)playerRoundHand.RoundId;
            return result;
        }

        public List<PlayerRoundHandGetFirstDealGameViewItem> MapPlayerRouondHandGetFirstDealGameViewItem(List<PlayerRoundHand> hands, List<Card> cards)
        {
            var result = new List<PlayerRoundHandGetFirstDealGameViewItem>();
            foreach(var hand in hands)
            {
                var viewItem = new PlayerRoundHandGetFirstDealGameViewItem();
                viewItem.Id = hand.Id;
                viewItem.Score = hand.Score;
                viewItem.PlayerId = hand.PlayerId;
                viewItem.Hand = MapCardToCardGetFirstDealGameViewItem(cards.Where(x=>x.PlayerRoundHandId==hand.Id).ToList());
                result.Add(viewItem);
            }
            return result;
        }

        public List<CardGetFirstDealGameViewItem> MapCardToCardGetFirstDealGameViewItem(List<Card> cards)
        {
            var result = new List<CardGetFirstDealGameViewItem>();
            foreach(var card in cards)
            {
                var viewItem = new CardGetFirstDealGameViewItem();
                viewItem.Name = card.Name.ToString();
                viewItem.Suit = card.Suit.ToString();
                viewItem.Value = (int)card.Value;
                result.Add(viewItem);
            }
            return result;
        }

        public PlayerRoundHandGetCardGameViewItem MapPlayerRoundHandToPlayerRoundHandGetCardGameViewItem(PlayerRoundHand hand, List<Card> cards)
        {
            var result = new PlayerRoundHandGetCardGameViewItem();
            result.Id = hand.Id;
            result.Score = hand.Score;
            result.PlayerId = hand.PlayerId;
            result.Hand = MapCardToCardGetCardGameViewItem(cards);
            return result;
        }

        public List<CardGetCardGameViewItem> MapCardToCardGetCardGameViewItem (List<Card> cards)
        {
            var result = new List<CardGetCardGameViewItem>();
            foreach (var card in cards)
            {
                var viewItem = new CardGetCardGameViewItem();
                viewItem.Name = card.Name.ToString();
                viewItem.Suit = card.Suit.ToString();
                result.Add(viewItem);
            }
            return result;
        }

        public PlayerRoundHandBotLogicGameViewItem MapPlayerRoundHandToPlayerRoundHandBotLogicGameViewItem(PlayerRoundHand hand,List<Card> cards)
        {
            var result = new PlayerRoundHandBotLogicGameViewItem();
            result.Id = hand.Id;
            result.Score = hand.Score;
            result.PlayerId = hand.PlayerId;
            result.Hand = MapCardToCardBotLogicGameViewItem(cards);
            return result;
        }

        public List<CardBotLogicGameViewItem> MapCardToCardBotLogicGameViewItem(List<Card> cards)
        {
            var result = new List<CardBotLogicGameViewItem>();
            foreach (var card in cards)
            {
                var viewItem = new CardBotLogicGameViewItem();
                viewItem.Name = card.Name.ToString();
                viewItem.Suit = card.Suit.ToString();
                result.Add(viewItem);
            }
            return result;
        }

        public RoundFindWinnerGameViewItem MapRoundToRoundFindWinnerGameViewItem(Round round)
        {
            var result = new RoundFindWinnerGameViewItem();

            result.Id = round.Id;
            result.RoundNumber = round.RoundNumber;
            result.Winner = round.Winner;
            result.WinnerScore = round.WinnerScore;
            result.GameId = round.GameId;

            return result;
        }
    }
}


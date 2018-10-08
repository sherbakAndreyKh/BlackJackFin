using BlackJack.Entities;
using BlackJack.ViewModels;
using System.Collections.Generic;
using BlackJack.ViewModels.ResponseModel;
using System.Linq;

namespace BlackJack.BusinessLogic.Maping
{
    public class GameServiceResponseMapProvider
    {
        public PlayerGameProcessGameViewItem MapPlayerToPlayerGameProccessGameViewItem(Player player, PlayerRoundHand playerRoundHands)
        {
            var result = new PlayerGameProcessGameViewItem();
            result.Id = player.Id;
            result.Name = player.Name;
            result.Role = (int)player.Role;
            result.PlayerRoundHand.Add(MapRoundHandToPlayerRoundHandGameProcessGameViewItem(playerRoundHands));
            return result;
        }

        public PlayerRoundHandGameProcessGameViewItem MapRoundHandToPlayerRoundHandGameProcessGameViewItem(PlayerRoundHand playerRoundhands)
        {
            var result = new PlayerRoundHandGameProcessGameViewItem();
            result.PlayerId = playerRoundhands.PlayerId;
            result.RoundId = (int)playerRoundhands.RoundId;
            return result;
        }

        public List<CardGameProcessGameViewItem> MapCardsToCardGameProcessGameViewItem(IEnumerable<Card> cardsList)
        {
            var result = new List<CardGameProcessGameViewItem>();

            foreach (var card in cardsList)
            {
                var CardView = new CardGameProcessGameViewItem();
                CardView.Id = card.Id;
                CardView.Name = card.Name;
                CardView.Suit = card.Suit;
                CardView.Value = card.Value;
                CardView.ImgPath = card.ImgPath;
                result.Add(CardView);
            }

            return result;
        }

        public GameGameProcessGameViewItem MapGameToGameGameProcessGameViewItem(Game game)
        {
            var result = new GameGameProcessGameViewItem();
            result.Id = game.Id;
            result.GameNumber = game.GameNumber;
            result.PlayersAmount = game.PlayersAmount;
            return result;
        }

        public RoundGameProcessGameViewItem MapRoundToRoundGameProcessGameViewItem(Round round)
        {
            var result = new RoundGameProcessGameViewItem();
            result.Id = round.Id;
            result.RoundNumber = round.RoundNumber;
            result.GameId = (int)round.GameId;
            result.Winner = round.Winner;
            result.WinnerScore = round.WinnerScore;
            return result;
        }

        public List<CardNewRoundGameViewItem> MapCardsToCardNewRoundGameViewItem(IEnumerable<Card> cardsList)
        {
            var result = new List<CardNewRoundGameViewItem>();

            foreach (var card in cardsList)
            {
                var CardView = new CardNewRoundGameViewItem();
                CardView.Id = card.Id;
                CardView.Name = card.Name;
                CardView.Suit = card.Suit;
                CardView.Value = card.Value;
                CardView.ImgPath = card.ImgPath;
                result.Add(CardView);
            }

            return result;
        }

        public GameNewRoundGameViewItem MapGameToGameNewRoundGameViewItem(Game round)
        {
            var result = new GameNewRoundGameViewItem();
            result.Id = round.Id;
            result.GameNumber = round.GameNumber;
            result.PlayersAmount = round.PlayersAmount;
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

        public PlayerNewRoundGameViewItem MapPlayerToPlayerNewRoundGameViewItem(Player player, PlayerRoundHand playerRoundHand)
        {
            var result = new PlayerNewRoundGameViewItem();
            result.Id = player.Id;
            result.Name = player.Name;
            result.Role = (int)player.Role;
            result.PlayerRoundHand.Add(MapRoundHandToPlayerRoundHandNewRoundGameViewItem(playerRoundHand));
            return result;
        }

        public List<PlayerNewRoundGameViewItem> MapPlayersToPlayerNewRoundGameViewItem(List<Player> playerList, List<PlayerRoundHand> playerRoundHandList)
        {
            var result = new List<PlayerNewRoundGameViewItem>();
            foreach(var player in playerList)
            {
            PlayerNewRoundGameViewItem playerViewModel = new PlayerNewRoundGameViewItem();
                playerViewModel.Id = player.Id;
                playerViewModel.Name = player.Name;
                playerViewModel.Role = (int)player.Role;
                playerViewModel.PlayerRoundHand.Add(MapRoundHandToPlayerRoundHandNewRoundGameViewItem(playerRoundHandList.Where(x => x.PlayerId == player.Id).FirstOrDefault()));
                result.Add(playerViewModel);
            }
            return result;
        }
        public PlayerRoundHandNewRoundGameViewItem MapRoundHandToPlayerRoundHandNewRoundGameViewItem(PlayerRoundHand playerRoundHand)
        {
            var result = new PlayerRoundHandNewRoundGameViewItem();
            result.PlayerId = playerRoundHand.PlayerId;
            result.RoundId = (int)playerRoundHand.RoundId;
            return result;
        }

    }   
}


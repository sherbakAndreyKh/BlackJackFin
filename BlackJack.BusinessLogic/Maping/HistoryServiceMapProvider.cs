using System.Collections.Generic;
using System.Linq;
using BlackJack.Entities;
using BlackJack.ViewModels;

namespace BlackJack.BusinessLogic.Maping
{
    public class HistoryServiceMapProvider
    {
        public List<PlayerIndexHistoryViewItem> MapPlayersToPlayerIndexHistoryViewItem(List<Player> playersList)
        {
            var result = new List<PlayerIndexHistoryViewItem>();
            foreach(var player in playersList)
            {
                var PlayerViewItem = new PlayerIndexHistoryViewItem();
                PlayerViewItem.Id = player.Id;
                PlayerViewItem.Name = player.Name;
                result.Add(PlayerViewItem);
            }
            return result;
        }

        public List<GameGameListHistoryViewItem> MapGamesToGameGameListHistoryViewItem(List<Game> gamesList)
        {
            var result = new List<GameGameListHistoryViewItem>();
            foreach(var game in gamesList)
            {
                var GameViewItem = new GameGameListHistoryViewItem();
                GameViewItem.Id = game.Id;
                GameViewItem.Number = game.GameNumber;
                result.Add(GameViewItem);
            }
            return result;
        }

        public PlayerGameListHistoryViewItem MapPlayerToPlayerGameListHistoryViewItem(Player player)
        {
            var result = new PlayerGameListHistoryViewItem();
            result.Id = player.Id;
            result.Name = player.Name;
            return result;
        }

        public List<RoundRoundListHistoryViewItem> MapListRoundToRoundRoundListHistoryViewItem(List<Round> roundsList)
        {
            var result = new List<RoundRoundListHistoryViewItem>();
            foreach(var round in roundsList)
            {
                var RoundViewModel = new RoundRoundListHistoryViewItem();
                RoundViewModel.Id = round.Id;
                RoundViewModel.RoundNumber = round.RoundNumber;
                RoundViewModel.Winner = round.Winner;
                RoundViewModel.WinnerScore = round.WinnerScore;
                result.Add(RoundViewModel);
            }
            return result;
        }

        public List<PlayerDetailsRoundHistoryViewItem> MapPlayersToPlayerDetailsRoundHistoryViewItem(List<Player> playersList, List<PlayerRoundHand> plyerRoundHandsList, List<Card> cardsList)
        {
            var result = new List<PlayerDetailsRoundHistoryViewItem>();
            foreach(var details in playersList)
            {
                var DetailsViewModel = new PlayerDetailsRoundHistoryViewItem();
                DetailsViewModel.Name = details.Name;
                DetailsViewModel.PlayerRoundHands = MapPlayersRoundHandToPlayerRoundHandDetailsRoundHistoryViewItem(plyerRoundHandsList.Where(x=>x.PlayerId==details.Id).ToList(), cardsList);
                result.Add(DetailsViewModel);
            }
            return result;
        }

        public List<PlayerRoundHandDetailsRoundHistoryViewItem> MapPlayersRoundHandToPlayerRoundHandDetailsRoundHistoryViewItem(List<PlayerRoundHand> playerRoundHandsList, List<Card> cardsList)
        {
            var result = new List<PlayerRoundHandDetailsRoundHistoryViewItem>();
            foreach(var properties in playerRoundHandsList)
            {
                var PropertiesViewModel = new PlayerRoundHandDetailsRoundHistoryViewItem();
                PropertiesViewModel.Score = properties.Score;
                PropertiesViewModel.PlayerId = (int)properties.PlayerId;
                PropertiesViewModel.Hand = MapCardsToCardDetailsRoundHistoryViewItem(cardsList.Where(x=>x.Id==properties.Id).ToList());
                result.Add(PropertiesViewModel);
            }
            return result;
        }

        public List<CardDetailsRoundHistoryViewItem> MapCardsToCardDetailsRoundHistoryViewItem(List<Card> cardsList)
        {
            var result = new List<CardDetailsRoundHistoryViewItem>();
            foreach(var card in cardsList)
            {
                var CardViewItem = new CardDetailsRoundHistoryViewItem();
                CardViewItem.Name = card.Name;
                CardViewItem.Suit = card.Suit;
                result.Add(CardViewItem);
            }
            return result;
        }
    }
}

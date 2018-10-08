using System.Collections.Generic;
using System.Linq;
using BlackJack.Entities;
using BlackJack.ViewModels;

namespace BlackJack.BusinessLogic.Maping
{
    public class HistoryServiceMapProvider
    {
        public List<PlayerIndexHistoryViewItem> MapListPlayerOnPlayerIndexHistoryViewItem(List<Player> data)
        {
            var result = new List<PlayerIndexHistoryViewItem>();

            foreach(var player in data)
            {
                var PlayerViewItem = new PlayerIndexHistoryViewItem();
                PlayerViewItem.Id = player.Id;
                PlayerViewItem.Name = player.Name;
                result.Add(PlayerViewItem);
            }
            return result;
        }

        public List<GameGameListHistoryViewItem> MapListGameOnGameGameListHistoryViewItem(List<Game> data)
        {
            var result = new List<GameGameListHistoryViewItem>();

            foreach(var game in data)
            {
                var GameViewItem = new GameGameListHistoryViewItem();
                GameViewItem.Id = game.Id;
                GameViewItem.Number = game.GameNumber;
                result.Add(GameViewItem);
            }

            return result;
        }

        public ViewModels.PlayerGameListHistoryViewItem MapPlayerOnPlayerGameListHistoryViewItem(Player data)
        {
            var result = new PlayerGameListHistoryViewItem();
            result.Id = data.Id;
            result.Name = data.Name;

            return result;
        }

        public List<ViewModels.RoundRoundListHistoryViewItem> MapListRoundOnRoundRoundListHistoryViewItem(List<Round> data)
        {
            var result = new List<RoundRoundListHistoryViewItem>();

            foreach(var round in data)
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

        public List<PlayerDetailsRoundHistoryViewItem> MapListPlayerOnPlayerDetailsRoundHistoryViewItem(List<Player> data, List<PlayerRoundHand> properties, List<Card> cards)
        {
            var result = new List<PlayerDetailsRoundHistoryViewItem>();

            foreach(var details in data)
            {
                var DetailsViewModel = new PlayerDetailsRoundHistoryViewItem();
                DetailsViewModel.Name = details.Name;
                DetailsViewModel.PlayerRoundHands = MapListPlayerRoundHandOnPlayerRoundHandDetailsRoundHistoryViewItem(properties.Where(x=>x.PlayerId==details.Id).ToList(), cards);
                result.Add(DetailsViewModel);
            }

            return result;
        }

        public List<PlayerRoundHandDetailsRoundHistoryViewItem> MapListPlayerRoundHandOnPlayerRoundHandDetailsRoundHistoryViewItem(List<PlayerRoundHand> data, List<Card> cards)
        {
            var result = new List<PlayerRoundHandDetailsRoundHistoryViewItem>();

            foreach(var properties in data)
            {
                var PropertiesViewModel = new PlayerRoundHandDetailsRoundHistoryViewItem();
                PropertiesViewModel.Score = properties.Score;
                PropertiesViewModel.PlayerId = (int)properties.PlayerId;
                PropertiesViewModel.Hand = MapListCardOnCardDetailsRoundHistoryViewItem(cards.Where(x=>x.Id==properties.Id).ToList());
                result.Add(PropertiesViewModel);
            }

            return result;
        }

        public List<CardDetailsRoundHistoryViewItem> MapListCardOnCardDetailsRoundHistoryViewItem(List<Card> data)
        {
            var result = new List<CardDetailsRoundHistoryViewItem>();

            foreach(var card in data)
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

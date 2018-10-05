using System.Collections.Generic;
using System.Linq;
using BlackJack.Entities;

namespace BlackJack.BusinessLogicLayer.Maping
{
    public class HistoryServiceMappProvider
    {
        public List<ViewModels.ResponseModel.PlayerIndexHistoryViewItem> MapListPlayerOnPlayerIndexHistoryViewItem(List<Player> data)
        {
            var result = new List<ViewModels.ResponseModel.PlayerIndexHistoryViewItem>();

            foreach(var player in data)
            {
                var PlayerViewItem = new ViewModels.ResponseModel.PlayerIndexHistoryViewItem();
                PlayerViewItem.Id = player.Id;
                PlayerViewItem.Name = player.Name;
                result.Add(PlayerViewItem);
            }
            return result;
        }

        public List<ViewModels.ResponseModel.GameGameListHistoryViewItem> MapListGameOnGameGameListHistoryViewItem(List<Game> data)
        {
            var result = new List<ViewModels.ResponseModel.GameGameListHistoryViewItem>();

            foreach(var game in data)
            {
                var GameViewItem = new ViewModels.ResponseModel.GameGameListHistoryViewItem();
                GameViewItem.Id = game.Id;
                GameViewItem.Number = game.NumberGame;
                result.Add(GameViewItem);
            }

            return result;
        }

        public ViewModels.ResponseModel.PlayerGameListHistoryViewItem MapPlayerOnPlayerGameListHistoryViewItem(Player data)
        {
            var result = new ViewModels.ResponseModel.PlayerGameListHistoryViewItem();
            result.Id = data.Id;
            result.Name = data.Name;

            return result;
        }

        public List<ViewModels.ResponseModel.RoundRoundListHistoryViewItem> MapListRoundOnRoundRoundListHistoryViewItem(List<Round> data)
        {
            var result = new List<ViewModels.ResponseModel.RoundRoundListHistoryViewItem>();

            foreach(var round in data)
            {
                var RoundViewModel = new ViewModels.ResponseModel.RoundRoundListHistoryViewItem();
                RoundViewModel.Id = round.Id;
                RoundViewModel.NumberRound = round.NumberRound;
                RoundViewModel.Winner = round.Winner;
                RoundViewModel.WinnerScore = round.WinnerScore;
                result.Add(RoundViewModel);
            }

            return result;
        }

        public List<ViewModels.ResponseModel.PlayerDetailsRoundHistoryViewItem> MapListPlayerOnPlayerDetailsRoundHistoryViewItem(List<Player> data, List<PlayerRoundHand> properties, List<Card> cards)
        {
            var result = new List<ViewModels.ResponseModel.PlayerDetailsRoundHistoryViewItem>();

            foreach(var details in data)
            {
                var DetailsViewModel = new ViewModels.ResponseModel.PlayerDetailsRoundHistoryViewItem();
                DetailsViewModel.Name = details.Name;
                DetailsViewModel.Properties = MapListPlayerRoundHandOnPlayerRoundHandDetailsRoundHistoryViewItem(properties.Where(x=>x.PlayerId==details.Id).ToList(), cards);
                result.Add(DetailsViewModel);
            }

            return result;
        }

        public List<ViewModels.ResponseModel.PlayerRoundHandDetailsRoundHistoryViewItem> MapListPlayerRoundHandOnPlayerRoundHandDetailsRoundHistoryViewItem(List<PlayerRoundHand> data, List<Card> cards)
        {
            var result = new List<ViewModels.ResponseModel.PlayerRoundHandDetailsRoundHistoryViewItem>();

            foreach(var properties in data)
            {
                var PropertiesViewModel = new ViewModels.ResponseModel.PlayerRoundHandDetailsRoundHistoryViewItem();
                PropertiesViewModel.Score = properties.Score;
                PropertiesViewModel.PlayerId = (int)properties.PlayerId;
                PropertiesViewModel.Hand = MapListCardOnCardDetailsRoundHistoryViewItem(cards.Where(x=>x.Id==properties.Id).ToList());
                result.Add(PropertiesViewModel);
            }

            return result;
        }

        public List<ViewModels.ResponseModel.CardDetailsRoundHistoryViewItem> MapListCardOnCardDetailsRoundHistoryViewItem(List<Card> data)
        {
            var result = new List<ViewModels.ResponseModel.CardDetailsRoundHistoryViewItem>();

            foreach(var card in data)
            {
                var CardViewItem = new ViewModels.ResponseModel.CardDetailsRoundHistoryViewItem();
                CardViewItem.Name = card.Name;
                CardViewItem.Suit = card.Suit;
                result.Add(CardViewItem);
            }

            return result;
        }
    }
}

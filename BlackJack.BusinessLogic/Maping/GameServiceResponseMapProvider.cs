using BlackJack.Entities;
using BlackJack.ViewModels;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Maping
{
    public class GameServiceResponseMapProvider
    {
        public ViewModels.ResponseModel.PlayerGameProcessGameViewItem MapPlayerOnPlayerGameProccessGameViewItem(Player player, PlayerRoundHand properties)
        {
            var result = new ViewModels.ResponseModel.PlayerGameProcessGameViewItem();
            result.Id = player.Id;
            result.Name = player.Name;
            result.Role = (int)player.Role;
            result.PlayerRoundHand.Add(MapRoundHandOnPlayerPropertiesGameProcessGameViewItem(properties));
            return result;
        }

        public ViewModels.ResponseModel.PlayerRoundHandGameProcessGameViewItem MapRoundHandOnPlayerPropertiesGameProcessGameViewItem(PlayerRoundHand properties)
        {
            var result = new ViewModels.ResponseModel.PlayerRoundHandGameProcessGameViewItem();
            result.PlayerId = properties.PlayerId;
            result.RoundId = (int)properties.RoundId;
            return result;
        }

        public List<ViewModels.ResponseModel.CardGameProcessGameViewItem> MapCardsOnCardGameProcessGameViewItem(IEnumerable<Card> cards)
        {
            var result = new List<ViewModels.ResponseModel.CardGameProcessGameViewItem>();

            foreach (var a in cards)
            {
                var CardView = new ViewModels.ResponseModel.CardGameProcessGameViewItem();
                CardView.Id = a.Id;
                CardView.Name = a.Name;
                CardView.Suit = a.Suit;
                CardView.Value = a.Value;
                CardView.ImgPath = a.ImgPath;
                result.Add(CardView);
            }

            return result;
        }

        public ViewModels.ResponseModel.GameGameProcessGameViewItem MapGameOnGameGameProcessGameViewItem(Game item)
        {
            var result = new ViewModels.ResponseModel.GameGameProcessGameViewItem();
            result.Id = item.Id;
            result.GameNumber = item.GameNumber;
            result.PlayersAmount = item.PlayersAmount;
            return result;
        }

        public ViewModels.ResponseModel.RoundGameProcessGameViewItem MapRoundOnRoundGameProcessGameViewItem(Round item)
        {
            var result = new ViewModels.ResponseModel.RoundGameProcessGameViewItem();
            result.Id = item.Id;
            result.RoundNumber = item.RoundNumber;
            result.GameId = (int)item.GameId;
            result.Winner = item.Winner;
            result.WinnerScore = item.WinnerScore;
            return result;
        }

        public List<CardNewRoundGameViewItem> MapCardsOnCardNewRoundGameViewItem(IEnumerable<Card> cards)
        {
            var result = new List<CardNewRoundGameViewItem>();

            foreach (var a in cards)
            {
                var CardView = new CardNewRoundGameViewItem();
                CardView.Id = a.Id;
                CardView.Name = a.Name;
                CardView.Suit = a.Suit;
                CardView.Value = a.Value;
                CardView.ImgPath = a.ImgPath;
                result.Add(CardView);
            }

            return result;
        }

        public GameNewRoundGameViewItem MapGameOnGameNewRoundGameViewItem(Game item)
        {
            var result = new GameNewRoundGameViewItem();
            result.Id = item.Id;
            result.GameNumber = item.GameNumber;
            result.PlayersAmount = item.PlayersAmount;
            return result;
        }

        public RoundNewRoundGameViewItem MapRoundOnRoundNewRoundGameViewItem(Round item)
        {
            var result = new RoundNewRoundGameViewItem();
            result.Id = item.Id;
            result.RoundNumber = item.RoundNumber;
            result.GameId = (int)item.GameId;
            result.Winner = item.Winner;
            result.WinnerScore = item.WinnerScore;
            return result;
        }

        public PlayerNewRoundGameViewItem MapPlayerOnPlayerNewRoundGameViewItem(Player player, PlayerRoundHand properties)
        {
            var result = new PlayerNewRoundGameViewItem();
            result.Id = player.Id;
            result.Name = player.Name;
            result.Role = (int)player.Role;
            result.PlayerRoundHand.Add(MapRoundHandOnPlayerRoundHandNewRoundGameViewItem(properties));
            return result;
        }

        public PlayerRoundHandNewRoundGameViewItem MapRoundHandOnPlayerRoundHandNewRoundGameViewItem(PlayerRoundHand properties)
        {
            var result = new PlayerRoundHandNewRoundGameViewItem();
            result.PlayerId = properties.PlayerId;
            result.RoundId = (int)properties.RoundId;
            return result;
        }
    }   
}


using BlackJack.Entities;
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
            result.Properties.Add(MapRoundHandOnPlayerPropertiesGameProcessGameViewItem(properties));
            return result;
        }

        public ViewModels.ResponseModel.PlayerPropertiesGameProcessGameViewItem MapRoundHandOnPlayerPropertiesGameProcessGameViewItem(PlayerRoundHand properties)
        {
            var result = new ViewModels.ResponseModel.PlayerPropertiesGameProcessGameViewItem();
            result.PlayerId = properties.PlayerId;
            result.Round_Id = (int)properties.RoundId;
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
            result.NumberGame = item.NumberGame;
            result.AmountPlayers = item.AmountPlayers;
            return result;
        }

        public ViewModels.ResponseModel.RoundGameProcessGameViewItem MapRoundOnRoundGameProcessGameViewItem(Round item)
        {
            var result = new ViewModels.ResponseModel.RoundGameProcessGameViewItem();
            result.Id = item.Id;
            result.NumberRound = item.NumberRound;
            result.GameId = (int)item.GameId;
            result.Winner = item.Winner;
            result.WinnerScore = item.WinnerScore;
            return result;
        }

        public List<ViewModels.ResponseModel.CardNewRoundGameViewItem> MapCardsOnCardNewRoundGameViewItem(IEnumerable<Card> cards)
        {
            var result = new List<ViewModels.ResponseModel.CardNewRoundGameViewItem>();

            foreach (var a in cards)
            {
                var CardView = new ViewModels.ResponseModel.CardNewRoundGameViewItem();
                CardView.Id = a.Id;
                CardView.Name = a.Name;
                CardView.Suit = a.Suit;
                CardView.Value = a.Value;
                CardView.ImgPath = a.ImgPath;
                result.Add(CardView);
            }

            return result;
        }

        public ViewModels.ResponseModel.GameNewRoundGameViewItem MapGameOnGameNewRoundGameViewItem(Game item)
        {
            var result = new ViewModels.ResponseModel.GameNewRoundGameViewItem();
            result.Id = item.Id;
            result.NumberGame = item.NumberGame;
            result.AmountPlayers = item.AmountPlayers;
            return result;
        }

        public ViewModels.ResponseModel.RoundNewRoundGameViewItem MapRoundOnRoundNewRoundGameViewItem(Round item)
        {
            var result = new ViewModels.ResponseModel.RoundNewRoundGameViewItem();
            result.Id = item.Id;
            result.NumberRound = item.NumberRound;
            result.GameId = (int)item.GameId;
            result.Winner = item.Winner;
            result.WinnerScore = item.WinnerScore;
            return result;
        }

        public ViewModels.ResponseModel.PlayerNewRoundGameViewItem MapPlayerOnPlayerNewRoundGameViewItem(Player player, PlayerRoundHand properties)
        {
            var result = new ViewModels.ResponseModel.PlayerNewRoundGameViewItem();
            result.Id = player.Id;
            result.Name = player.Name;
            result.Role = (int)player.Role;
            result.Properties.Add(MapRoundHandOnPlayerRoundHandNewRoundGameViewItem(properties));
            return result;
        }

        public ViewModels.ResponseModel.PlayerRoundHandNewRoundGameViewItem MapRoundHandOnPlayerRoundHandNewRoundGameViewItem(PlayerRoundHand properties)
        {
            var result = new ViewModels.ResponseModel.PlayerRoundHandNewRoundGameViewItem();
            result.PlayerId = properties.PlayerId;
            result.Round_Id = (int)properties.RoundId;
            return result;
        }
    }   
}


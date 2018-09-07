using BlackJack.Entities;
using BlackJack.Entities.History;
using System.Collections.Generic;

namespace BlackJack.BusinessLogicLayer.Mapping
{
    public class GameServiceResponseMappProvider
    {
        public ViewModels.ResponseModel.PlayerGameProcessGameViewItem MapPlayer(Player player, PlayerProperties properties)
        {
            var result = new ViewModels.ResponseModel.PlayerGameProcessGameViewItem();
            result.Id = player.Id;
            result.Name = player.Name;
            result.Role = (int)player.Role;
            result.Properties.Add(MapProperties(properties));
            return result;
        }

        public ViewModels.ResponseModel.PlayerPropertiesGameProcessGameViewItem MapProperties(PlayerProperties properties)
        {
            var result = new ViewModels.ResponseModel.PlayerPropertiesGameProcessGameViewItem();
            result.PlayerId = properties.PlayerId;
            result.Round_Id = properties.Round_Id;
            return result;
        }

        public List<ViewModels.ResponseModel.CardGameProcessGameViewItem> MapCards(IEnumerable<Card> cards)
        {
            var result = new List<ViewModels.ResponseModel.CardGameProcessGameViewItem>();
            foreach (var a in cards)
            {
                var CardView = new ViewModels.ResponseModel.CardGameProcessGameViewItem();
                CardView.Name = a.Name;
                CardView.Suit = a.Suit;
                CardView.Value = a.Value;
                CardView.ImgPath = a.ImgPath;
                result.Add(CardView);
            }
            return result;
        }

        public List<Card> MapCards(IEnumerable<ViewModels.RequestModel.CardGameProcessGameViewItem> cards)
        {
            var result = new List<Card>();
            foreach(var a in cards)
            {
                var CardView = new Card();
                CardView.Name = a.Name;
                CardView.Suit = a.Suit;
                CardView.Value = a.Value;
                CardView.ImgPath = a.ImgPath;
                result.Add(CardView);
            }

            return result;
        }

        public ViewModels.ResponseModel.GameGameProcessGameViewItem MapGame(Game item)
        {
            var result = new ViewModels.ResponseModel.GameGameProcessGameViewItem();
            result.Id = item.Id;
            result.NumberGame = item.NumberGame;
            return result;
        }

        public ViewModels.ResponseModel.RoundGameProcessGameViewItem MapRound(Round item)
        {
            var result = new ViewModels.ResponseModel.RoundGameProcessGameViewItem();
            result.Id = item.Id;
            result.NumberRound = item.NumberRound;
            result.GameId = (int)item.GameId;
            result.Winner = item.Winner;
            result.WinnerScore = item.WinnerScore;
            return result;
        }




    }
}

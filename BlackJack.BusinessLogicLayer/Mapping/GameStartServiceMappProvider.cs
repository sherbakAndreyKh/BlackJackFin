using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels;
using BlackJack.Entities;
using BlackJack.Entities.History;


namespace BlackJack.BusinessLogicLayer.Mapping
{
    public class GameStartServiceResponseMappProvider
    {
        public PlayersResponseGameViewModelItem MapPlayer(Player player, PlayerProperties properties)
        {
            var result = new PlayersResponseGameViewModelItem();
            result.Name = player.Name;
            result.Role = (int)player.Role;
            result.Properties.Add(MapProperties(properties));
            return result;
        }

        public PlayerPropertiesResponseGameViewModelItem MapProperties(PlayerProperties properties)
        {
            var result = new PlayerPropertiesResponseGameViewModelItem();
            result.PlayerId = properties.PlayerId;
            result.Round_Id = properties.Round_Id;
            return result;
        }

        public List<CardResponseGameViewModelItem> MapCards(IEnumerable<Card> cards)
        {
            var result = new List<CardResponseGameViewModelItem>();
            foreach (var a in cards)
            {
                var CardView = new CardResponseGameViewModelItem();
                CardView.Name = a.Name;
                CardView.Suit = a.Suit;
                CardView.Value = a.Value;
                CardView.ImgPath = a.ImgPath;
                result.Add(CardView);
            }
            return result;
        }

        public GameResponseGameViewModelItem MapGame(Game item)
        {
            var result = new GameResponseGameViewModelItem();
            result.Id = item.Id;
            result.NumberGame = item.NumberGame;
            return result;
        }

        public RoundResponseGameViewModelItem MapRound(Round item)
        {
            var result = new RoundResponseGameViewModelItem();
            result.Id = item.Id;
            result.NumberRound = item.NumberRound;
            result.GameId = item.GameId;
            result.Winner = item.Winner;
            result.WinnerScore = item.WinnerScore;
            return result;
        }

    }
}

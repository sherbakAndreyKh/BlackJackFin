using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.Entities.History;

namespace BlackJack.BusinessLogicLayer.Mapping
{
    public class HistoryServiceMappProvider
    {
        public List<ViewModels.ResponseModel.PlayerIndexHistoryViewItem>  HistoryView (List<Player> data)
        {
            var result = new List<ViewModels.ResponseModel.PlayerIndexHistoryViewItem>();
            foreach(var player in data)
            {
                var PlayerViewItem = new ViewModels.ResponseModel.PlayerIndexHistoryViewItem();
                PlayerViewItem.Id = player.Id;
                PlayerViewItem.Name = player.Name;
                PlayerViewItem.GameAmount = player.Games.Count();

                result.Add(PlayerViewItem);
            }
            return result;
        }


        public List<ViewModels.ResponseModel.GameGameListHistoryViewItem> HistoryGamesView(List<Game> data)
        {
            var result = new List<ViewModels.ResponseModel.GameGameListHistoryViewItem>();
            foreach(var game in data)
            {
                var GameViewItem = new ViewModels.ResponseModel.GameGameListHistoryViewItem();
                GameViewItem.Id = game.Id;
                GameViewItem.Number = game.NumberGame;
                GameViewItem.AmountRounds = game.Rounds.Count();
                result.Add(GameViewItem);
            }
            return result;
        }

        public ViewModels.ResponseModel.PlayerGameListHistoryViewItem HistoryGamesPlayerView(Player data)
        {
            var result = new ViewModels.ResponseModel.PlayerGameListHistoryViewItem();
            result.Id = data.Id;
            result.Name = data.Name;

            return result;
        }

        public List<ViewModels.ResponseModel.RoundRoundListHistoryViewItem> HistoryGamesRoundView(List<Round> data)
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

       
    }
}

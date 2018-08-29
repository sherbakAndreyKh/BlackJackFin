using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class HistoryViewModel
    {
        public string PlayerName { get; set; }
        public int GameNumber { get; set; }
        public int RoundNumber { get; set; }

        public string Winner { get; set; }
        public int WinnerScore { get; set; }

        public int AmountPlayers { get; set; }

    }
    public class AddHistory
    {
        public int GameId { get; set; }
        public int RoundId { get; set; }
        public string PlayerName { get; set; }
        public List<CardGameViewModelItem> Cards { get; set; }
        public int Score { get; set; }

        public AddHistory()
        {
            Cards = new List<CardGameViewModelItem>();
        }
    }
}

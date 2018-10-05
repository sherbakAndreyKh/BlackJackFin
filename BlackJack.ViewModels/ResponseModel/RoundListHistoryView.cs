using System.Collections.Generic;

namespace BlackJack.ViewModels.ResponseModel
{
    public class RoundListHistoryView
    {
       public int AmountPlayers { get; set; }
       public List<RoundRoundListHistoryViewItem> Rounds { get; set; }
    }

    public class RoundRoundListHistoryViewItem
    {
        public long Id { get; set; }
        public string Winner { get; set; }
        public int WinnerScore { get; set; }
        public long NumberRound { get; set; }
    }
}

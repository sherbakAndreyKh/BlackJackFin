using System.Collections.Generic;

namespace BlackJack.ViewModels
{
    public class RoundListHistoryView
    {
       public int PlayersAmount { get; set; }
       public List<RoundRoundListHistoryViewItem> Rounds { get; set; }
    }

    public class RoundRoundListHistoryViewItem
    {
        public long Id { get; set; }
        public string Winner { get; set; }
        public int WinnerScore { get; set; }
        public long RoundNumber { get; set; }
    }
}

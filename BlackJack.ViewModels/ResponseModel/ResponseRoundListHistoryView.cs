using System.Collections.Generic;

namespace BlackJack.ViewModels.ResponseModel
{
    public class ResponseRoundListHistoryView
    {
       public int AmountPlayers { get; set; }
       public List<RoundRoundListHistoryViewItem> Rounds { get; set; }
    }

    public class RoundRoundListHistoryViewItem
    {
        public int Id { get; set; }
        public string Winner { get; set; }
        public int WinnerScore { get; set; }
        public int NumberRound { get; set; }
    }
}

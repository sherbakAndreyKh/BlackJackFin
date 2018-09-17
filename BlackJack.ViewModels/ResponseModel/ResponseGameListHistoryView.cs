using System.Collections.Generic;

namespace BlackJack.ViewModels.ResponseModel
{
    public class ResponseGameListHistoryView
    {
        public PlayerGameListHistoryViewItem Player { get; set; }
        public List<GameGameListHistoryViewItem> Games { get; set; }

        public ResponseGameListHistoryView()
        {
            Games = new List<GameGameListHistoryViewItem>();
        }
    }

    public class GameGameListHistoryViewItem
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int AmountRounds { get; set; }
    }

    public class PlayerGameListHistoryViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

using System.Collections.Generic;

namespace BlackJack.ViewModels.ResponseModel
{
    public class GameListHistoryView
    {
        public PlayerGameListHistoryViewItem Player { get; set; }
        public List<GameGameListHistoryViewItem> Games { get; set; }

        public GameListHistoryView()
        {
            Games = new List<GameGameListHistoryViewItem>();
        }
    }

    public class GameGameListHistoryViewItem
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public int AmountRounds { get; set; }
    }

    public class PlayerGameListHistoryViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}

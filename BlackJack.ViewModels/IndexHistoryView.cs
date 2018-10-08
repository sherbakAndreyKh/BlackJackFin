using System.Collections.Generic;


namespace BlackJack.ViewModels
{
    public class IndexHistoryView
    {
        public List<PlayerIndexHistoryViewItem> Players { get; set; }

        public IndexHistoryView()
        {
            Players = new List<PlayerIndexHistoryViewItem>();
        }
    }

    public class PlayerIndexHistoryViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }        
        public int GameAmount { get; set; }
    }
}

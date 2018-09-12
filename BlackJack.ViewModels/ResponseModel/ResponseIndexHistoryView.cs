using System.Collections.Generic;


namespace BlackJack.ViewModels.ResponseModel
{
    public class ResponseIndexHistoryView
    {
        public List<PlayerIndexHistoryViewItem> Players { get; set; }

        public ResponseIndexHistoryView()
        {
            Players = new List<PlayerIndexHistoryViewItem>();
        }
    }


    public class PlayerIndexHistoryViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public int GameAmount { get; set; }
    }

}

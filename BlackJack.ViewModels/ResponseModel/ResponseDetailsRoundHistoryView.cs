using System.Collections.Generic;

namespace BlackJack.ViewModels.ResponseModel
{
    public class ResponseDetailsRoundHistoryView
    {
        public List<PlayerDetailsRoundHistoryViewItem> Players { get; set; } 
    }

    public class PlayerDetailsRoundHistoryViewItem
    {
        public string Name { get; set; }
        public virtual List<PlayerRoundHandDetailsRoundHistoryViewItem> Properties { get; set; }

        public PlayerDetailsRoundHistoryViewItem()
        {
            Properties = new List<PlayerRoundHandDetailsRoundHistoryViewItem>();
        }
    }

    public class PlayerRoundHandDetailsRoundHistoryViewItem
    {
        public virtual List<CardDetailsRoundHistoryViewItem> Hand { get; set; }
        public int Score { get; set; }
        public int PlayerId { get; set; }
        public PlayerDetailsRoundHistoryViewItem Player { get; set; }
        public int Round_Id { get; set; }

        public PlayerRoundHandDetailsRoundHistoryViewItem()
        {
            Hand = new List<CardDetailsRoundHistoryViewItem>();
        }
    }

    public class CardDetailsRoundHistoryViewItem
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public string ImgPath { get; set; }
    }
}

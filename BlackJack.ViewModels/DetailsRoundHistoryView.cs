using System.Collections.Generic;

namespace BlackJack.ViewModels
{
    public class DetailsRoundHistoryView
    {
        public List<PlayerDetailsRoundHistoryViewItem> Players { get; set; } 
    }

    public class PlayerDetailsRoundHistoryViewItem
    {
        public string Name { get; set; }
        public List<PlayerRoundHandDetailsRoundHistoryViewItem> PlayerRoundHands { get; set; }

        public PlayerDetailsRoundHistoryViewItem()
        {
            PlayerRoundHands = new List<PlayerRoundHandDetailsRoundHistoryViewItem>();
        }
    }

    public class PlayerRoundHandDetailsRoundHistoryViewItem
    {
        public List<CardDetailsRoundHistoryViewItem> Hand { get; set; }
        public int Score { get; set; }
        public long PlayerId { get; set; }
        public PlayerDetailsRoundHistoryViewItem Player { get; set; }
        public long RoundId { get; set; }

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

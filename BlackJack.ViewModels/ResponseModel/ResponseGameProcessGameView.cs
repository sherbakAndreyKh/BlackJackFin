using System.Collections.Generic;

namespace BlackJack.ViewModels.ResponseModel
{
    public class ResponseGameProcessGameView
    {
        public GameGameProcessGameViewItem Game { get; set; }
        public RoundGameProcessGameViewItem Round { get; set; }
        public PlayerGameProcessGameViewItem Player { get; set; }
        public PlayerGameProcessGameViewItem Dealer { get; set; }
        public List<PlayerGameProcessGameViewItem> Bots { get; set; }

        public string Winner { get; set; }

        public ResponseGameProcessGameView()
        {
            Bots = new List<PlayerGameProcessGameViewItem>();
        }
    }

    public class PlayerGameProcessGameViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public PlayerRoundHandGameProcessGameViewItem PlayerRoundHand { get; set; }     
    }

    public class PlayerRoundHandGameProcessGameViewItem
    {
        public int Id { get;set; }
        public List<CardGameProcessGameViewItem> Hand { get; set; }
        public int Score { get; set; }
        public long PlayerId { get; set; }
        public PlayerRoundHandGameProcessGameViewItem()
        {
            Hand = new List<CardGameProcessGameViewItem>();
        }
    }

    public class CardGameProcessGameViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Suit { get; set; }
        public string ImgPath { get; set; }
    }

    public class GameGameProcessGameViewItem
    {
        public long Id { get; set; }
        public long GameNumber { get; set; }
    }

    public class RoundGameProcessGameViewItem
    {
        public long Id { get; set; }
        public long RoundNumber { get; set; }
        public string Winner { get; set; }
    }
}
 
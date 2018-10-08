using System.Collections.Generic;


namespace BlackJack.ViewModels.RequestModel
{
    public class RequestGameProcessGameView
    {
        public GameGameProcessGameViewItem Game { get; set; }
        public RoundGameProcessGameViewItem Round { get; set; }
        public PlayerGameProcessGameViewItem Dealer { get; set; }
        public PlayerGameProcessGameViewItem Player { get; set; }

        public List<CardGameProcessGameViewItem> CardDeck { get; set; }
        public List<PlayerGameProcessGameViewItem> Bots { get; set; }

        public RequestGameProcessGameView()
        {
            CardDeck = new List<CardGameProcessGameViewItem>();
            Bots = new List<PlayerGameProcessGameViewItem>();
        }
    }

    public class CardGameProcessGameViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public string ImgPath { get; set; }
    }

    public class PlayerGameProcessGameViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public List<PlayerRoundHandGameProcessGameViewItem> PlayerRoundHand { get; set; }

        public PlayerGameProcessGameViewItem()
        {
            PlayerRoundHand = new List<PlayerRoundHandGameProcessGameViewItem>();
        }
    }

    public class PlayerRoundHandGameProcessGameViewItem
    {
        public List<CardGameProcessGameViewItem> Hand { get; set; }
        public int Score { get; set; }

        public long PlayerId { get; set; }
        public long RoundId { get; set; }

        public PlayerRoundHandGameProcessGameViewItem()
        {
            Hand = new List<CardGameProcessGameViewItem>();
        }
    }

    public class GameGameProcessGameViewItem
    {
        public long Id { get; set; }
        public int PlayersAmount { get; set; }
        public long GameNumber { get; set; }

        public long PlayerId { get; set; }
        public PlayerGameProcessGameViewItem Player { get; set; }

        public List<RoundGameProcessGameViewItem> Rounds { get; set; }

        public GameGameProcessGameViewItem()
        {
            Rounds = new List<RoundGameProcessGameViewItem>();
        }
    }

    public class RoundGameProcessGameViewItem
    {
        public long Id { get; set; }
        public string Winner { get; set; }
        public int WinnerScore { get; set; }
        public int RoundNumber { get; set; }
        public long GameId { get; set; }
        public virtual GameGameProcessGameViewItem Game { get; set; }
    }
}

using System.Collections.Generic;

namespace BlackJack.ViewModels.ResponseModel
{
    public class ResponseNewRoundGameView
    {
        public GameNewRoundGameViewItem Game { get; set; }
        public RoundNewRoundGameViewItem Round { get; set; }
        public PlayerNewRoundGameViewItem Player { get; set; }
        public PlayerNewRoundGameViewItem Dealer { get; set; }
        public List<PlayerNewRoundGameViewItem> Bots { get; set; }

        public string Winner { get; set; }

        public ResponseNewRoundGameView()
        {
            Bots = new List<PlayerNewRoundGameViewItem>();
        }
    }

    public class PlayerNewRoundGameViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public PlayerRoundHandNewRoundGameViewItem PlayerRoundHand { get; set; }
    }

    public class PlayerRoundHandNewRoundGameViewItem
    {
        public long Id { get; set; }
        public List<CardNewRoundGameViewItem> Hand { get; set; }
        public int Score { get; set; }
        public long PlayerId { get; set; }
        public long RoundId { get; set; }
        public PlayerRoundHandNewRoundGameViewItem()
        {
            Hand = new List<CardNewRoundGameViewItem>();
        }
    }

    public class CardNewRoundGameViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Suit { get; set; }
        public string ImgPath { get; set; }
    }

    public class GameNewRoundGameViewItem
    {
        public long Id { get; set; }
        public long GameNumber { get; set; }
    }

    public class RoundNewRoundGameViewItem
    {
        public long Id { get; set; }
        public long RoundNumber { get; set; }
        public string Winner { get; set; }
        public long GameId { get; set; }
        public long WinnerScore { get; set; }
    }
}

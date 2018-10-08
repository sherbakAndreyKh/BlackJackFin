using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class NewRoundGameView
    {
        public GameNewRoundGameViewItem Game { get; set; }
        public RoundNewRoundGameViewItem Round { get; set; }
        public PlayerNewRoundGameViewItem Dealer { get; set; }
        public PlayerNewRoundGameViewItem Player { get; set; }

        public List<CardNewRoundGameViewItem> CardDeck { get; set; }
        public List<PlayerNewRoundGameViewItem> Bots { get; set; }

        public string Winner { get; set; }

        public NewRoundGameView()
        {
            CardDeck = new List<CardNewRoundGameViewItem>();
            Bots = new List<PlayerNewRoundGameViewItem>();
        }
    }

    public class CardNewRoundGameViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public string ImgPath { get; set; }
    }

    public class PlayerNewRoundGameViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public List<PlayerRoundHandNewRoundGameViewItem> PlayerRoundHand { get; set; }

        public PlayerNewRoundGameViewItem()
        {
            PlayerRoundHand = new List<PlayerRoundHandNewRoundGameViewItem>();
        }
    }

    public class PlayerRoundHandNewRoundGameViewItem
    {
        public List<CardNewRoundGameViewItem> Hand { get; set; }
        public int Score { get; set; }

        public long PlayerId { get; set; }
        public long RoundId { get; set; }

        public PlayerRoundHandNewRoundGameViewItem()
        {
            Hand = new List<CardNewRoundGameViewItem>();
        }
    }

    public class GameNewRoundGameViewItem
    {
        public long Id { get; set; }
        public int PlayersAmount { get; set; }
        public long GameNumber { get; set; }

        public long PlayerId { get; set; }
        public PlayerNewRoundGameViewItem Player { get; set; }
        public List<RoundNewRoundGameViewItem> Rounds { get; set; }

        public GameNewRoundGameViewItem()
        {
            Rounds = new List<RoundNewRoundGameViewItem>();
        }
    }

    public class RoundNewRoundGameViewItem
    {
        public long Id { get; set; }
        public string Winner { get; set; }
        public int WinnerScore { get; set; }
        public long RoundNumber { get; set; }
        public long GameId { get; set; }
        public GameNewRoundGameViewItem Game { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.ResponseModel
{
    public class ResponseGetFirstDealGameView
    {
        public List<PlayerRoundHandGetFirstDealGameViewItem> Hands { get; set; }
    }

    public class PlayerRoundHandGetFirstDealGameViewItem
    {
        public long Id { get; set; }
        public List<CardGetFirstDealGameViewItem> Hand { get; set; }
        public int Score { get; set; }
        public long PlayerId { get; set; }
        public PlayerRoundHandGetFirstDealGameViewItem()
        {
            Hand = new List<CardGetFirstDealGameViewItem>();
        }
    }

    public class CardGetFirstDealGameViewItem
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
    }
    public class RoundRoundHandGetFirstDealGameViewItem
    {
        public long Id { get; set; }
    }

    public enum CardNameFirstDealGameViewItem
    {
        None = 0,
        Two = 1,
        Three = 2,
        Four = 3,
        Five = 4,
        Six = 5,
        Seven = 6,
        Eight = 7,
        Nine = 8,
        Ten = 9,
        Jack = 10,
        Lady = 11,
        King = 12,
        Ace = 13
    }

    public enum CardSuitFirstDealGameViewItem
    {
        None = 0,
        Diamonds = 1,
        Hearts = 2,
        Spades = 3,
        Clubs = 4
    }

    public enum CardValueFirstDealGameViewItem
    {
        none = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eigth = 8,
        Nine = 9,
        Ten = 10,
        Eleven = 11
    }
}

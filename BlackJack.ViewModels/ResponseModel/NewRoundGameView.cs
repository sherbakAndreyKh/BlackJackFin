using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.ResponseModel
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
        public virtual List<PlayerRoundHandNewRoundGameViewItem> Properties { get; set; }

        public PlayerNewRoundGameViewItem()
        {
            Properties = new List<PlayerRoundHandNewRoundGameViewItem>();
        }
    }

    public class PlayerRoundHandNewRoundGameViewItem
    {
        public List<CardGameProcessGameViewItem> Hand { get; set; }
        public int Score { get; set; }

        public long? PlayerId { get; set; }

        public long Round_Id { get; set; }

        public PlayerRoundHandNewRoundGameViewItem()
        {
            Hand = new List<CardGameProcessGameViewItem>();
        }
    }

    public class GameNewRoundGameViewItem
    {
        public long Id { get; set; }
        public int AmountPlayers { get; set; }
        public long NumberGame { get; set; }

        public long PlayerId { get; set; }
        public PlayerNewRoundGameViewItem player { get; set; }

        public virtual List<RoundNewRoundGameViewItem> Rounds { get; set; }

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
        public long NumberRound { get; set; }
        public long GameId { get; set; }
        public virtual GameNewRoundGameViewItem Game { get; set; }
    }
}

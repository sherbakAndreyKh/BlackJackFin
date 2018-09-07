using System.Collections.Generic;

namespace BlackJack.ViewModels.ResponseModel
{
    public class ResponseGameProcessGameView
    {
        public GameGameProcessGameViewItem Game { get; set; }
        public RoundGameProcessGameViewItem Round { get; set; }
        public PlayerGameProcessGameViewItem Dealer { get; set; }
        public PlayerGameProcessGameViewItem Player { get; set; }

        public List<CardGameProcessGameViewItem> CardDeck { get; set; }
        public List<PlayerGameProcessGameViewItem> Bots { get; set; }

        public string Winner { get; set; }

        public ResponseGameProcessGameView()
        {
            CardDeck = new List<CardGameProcessGameViewItem>();
            Bots = new List<PlayerGameProcessGameViewItem>();
        }
    }

    public class CardGameProcessGameViewItem
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public string ImgPath { get; set; }
    }

    public class PlayerGameProcessGameViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public virtual List<PlayerPropertiesGameProcessGameViewItem> Properties { get; set; }

        public PlayerGameProcessGameViewItem()
        {
            Properties = new List<PlayerPropertiesGameProcessGameViewItem>();
        }

    }

    public class PlayerPropertiesGameProcessGameViewItem
    {
        public List<CardGameProcessGameViewItem> Hand { get; set; }
        public int Score { get; set; }

        public int? PlayerId { get; set; }

        public int Round_Id { get; set; }

        public PlayerPropertiesGameProcessGameViewItem()
        {
            Hand = new List<CardGameProcessGameViewItem>();
        }
    }

    public class GameGameProcessGameViewItem
    {
        public int Id { get; set; }
        public int AmountPlayers { get; set; }
        public int NumberGame { get; set; }

        public int PlayerId { get; set; }
        public PlayerGameProcessGameViewItem player { get; set; }

        public virtual List<RoundGameProcessGameViewItem> Rounds { get; set; }

        public GameGameProcessGameViewItem()
        {
            Rounds = new List<RoundGameProcessGameViewItem>();
        }
    }

    public class RoundGameProcessGameViewItem
    {
        public int Id { get; set; }
        public string Winner { get; set; }
        public int WinnerScore { get; set; }
        public int NumberRound { get; set; }
        public int GameId { get; set; }
        public virtual GameGameProcessGameViewItem Game { get; set; }
    }
}
 
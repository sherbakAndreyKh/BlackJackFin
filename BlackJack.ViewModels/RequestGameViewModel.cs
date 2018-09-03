using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class RequestGameViewModel
    {
        public GameRequestGameViewModelItem Game { get; set; }
        public RoundRequestGameViewModelItem Round { get; set; }
        public PlayersRequestGameViewModelItem Dealer { get; set; }
        public PlayersRequestGameViewModelItem Player { get; set; }

        public List<CardRequestGameViewModelItem> CardDeck { get; set; }
        public List<PlayersRequestGameViewModelItem> Bots { get; set; }

        public string Winner { get; set; }

        public RequestGameViewModel()
        {
            CardDeck = new List<CardRequestGameViewModelItem>();
            Bots = new List<PlayersRequestGameViewModelItem>();
        }
    }


    public class CardRequestGameViewModelItem
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public string ImgPath { get; set; }
    }


    public class PlayersRequestGameViewModelItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public virtual List<PlayerPropertiesRequestGameViewModelItem> Properties { get; set; }

        public PlayersRequestGameViewModelItem()
        {
            Properties = new List<PlayerPropertiesRequestGameViewModelItem>();
        }

    }

    public class PlayerPropertiesRequestGameViewModelItem
    {
        public List<CardRequestGameViewModelItem> Hand { get; set; }
        public int Score { get; set; }

        public int? PlayerId { get; set; }

        public int Round_Id { get; set; }

        public PlayerPropertiesRequestGameViewModelItem()
        {
            Hand = new List<CardRequestGameViewModelItem>();
        }
    }

    public class GameRequestGameViewModelItem
    {
        public int Id { get; set; }
        public int AmountPlayers { get; set; }
        public int NumberGame { get; set; }

        public int PlayerId { get; set; }
        public PlayersRequestGameViewModelItem player { get; set; }

        public virtual List<RoundRequestGameViewModelItem> Rounds { get; set; }

        public GameRequestGameViewModelItem()
        {
            Rounds = new List<RoundRequestGameViewModelItem>();
        }
    }

    public class RoundRequestGameViewModelItem
    {
        public int Id { get; set; }
        public string Winner { get; set; }
        public int WinnerScore { get; set; }
        public int NumberRound { get; set; }
        public int? GameId { get; set; }
        public virtual GameRequestGameViewModelItem Game { get; set; }
    }
}

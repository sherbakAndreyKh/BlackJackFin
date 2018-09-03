using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{

    public class ResponseGameViewModel
    {
        public GameResponseGameViewModelItem Game { get; set; }
        public RoundResponseGameViewModelItem Round { get; set; }
        public PlayersResponseGameViewModelItem Dealer { get; set; }
        public PlayersResponseGameViewModelItem Player { get; set; }

        public List<CardResponseGameViewModelItem> CardDeck { get; set; }
        public List<PlayersResponseGameViewModelItem> Bots { get; set; }

        public string Winner { get; set; }

        public ResponseGameViewModel()
        {
            CardDeck = new List<CardResponseGameViewModelItem>();
            Bots = new List<PlayersResponseGameViewModelItem>();
        }
    }


    public class CardResponseGameViewModelItem
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public string ImgPath { get; set; }
    }


    public class PlayersResponseGameViewModelItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public virtual List<PlayerPropertiesResponseGameViewModelItem> Properties { get; set; }

        public PlayersResponseGameViewModelItem()
        {
            Properties = new List<PlayerPropertiesResponseGameViewModelItem>();
        }

    }

    public class PlayerPropertiesResponseGameViewModelItem
    {
        public List<CardResponseGameViewModelItem> Hand { get; set; }
        public int Score { get; set; }

        public int? PlayerId { get; set; }

        public int Round_Id { get; set; }

        public PlayerPropertiesResponseGameViewModelItem()
        {
            Hand = new List<CardResponseGameViewModelItem>();
        }
    }

    public class GameResponseGameViewModelItem
    {
        public int Id { get; set; }
        public int AmountPlayers { get; set; }
        public int NumberGame { get; set; }

        public int PlayerId { get; set; }
        public PlayersResponseGameViewModelItem player { get; set; }

        public virtual List<RoundResponseGameViewModelItem> Rounds { get; set; }

        public GameResponseGameViewModelItem()
        {
            Rounds = new List<RoundResponseGameViewModelItem>();
        }
    }

    public class RoundResponseGameViewModelItem
    {
        public int Id { get; set; }
        public string Winner { get; set; }
        public int WinnerScore { get; set; }
        public int NumberRound { get; set; }
        public int? GameId { get; set; }
        public virtual GameResponseGameViewModelItem Game { get; set; }
    }
}
 
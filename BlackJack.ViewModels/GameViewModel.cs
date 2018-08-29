using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{

    public class GameViewModel
    {
        public int RoundId { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int GameNumber { get; set; }
        public int RoundNumber { get; set; }
        public PlayersGameViewModelItem Dealer { get; set; }
        public PlayersGameViewModelItem Player { get; set; }


        public List<CardGameViewModelItem> CardDeck { get; set; }

        public List<PlayersGameViewModelItem> Bots { get; set; }

        public string Winner { get; set; }

        public GameViewModel()
        {
            CardDeck = new List<CardGameViewModelItem>();
            Bots = new List<PlayersGameViewModelItem>();
           
        }
    }


    public class CardGameViewModelItem
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }

        public string ImgPath { get; set; }
    }


    public class PlayersGameViewModelItem
    {
        public string Name { get; set; }
        public int Role { get; set; }
        public virtual List<PlayerPropertiesGameViewModelItem> Properties { get; set; }

        public PlayersGameViewModelItem()
        {
            Properties = new List<PlayerPropertiesGameViewModelItem>();
        }

    }


    public class PlayerPropertiesGameViewModelItem
    {
        public List<CardGameViewModelItem> Hand { get; set; }
        public int Score { get; set; }

        public int? PlayerId { get; set; }

        public int Round_Id { get; set; }

        public PlayerPropertiesGameViewModelItem()
        {
            Hand = new List<CardGameViewModelItem>();
        }
    }





}

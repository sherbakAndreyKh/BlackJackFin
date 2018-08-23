using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{

    public class GameViewModel
    {
        public int GameNumber { get; set; }
        public int RoundNumber { get; set; }

        public IEnumerable<CardGameViewModelItem> Card { get; set; }
        public IEnumerable<PlayersGameViewModelItem> Players { get; set; }

        public string Winner { get; set; }

        public GameViewModel()
        {
            Card = new List<CardGameViewModelItem>();
            Players = new List<PlayersGameViewModelItem>();
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
        public virtual ICollection<PlayerPropertiesGameViewModelItem> Properties { get; set; }

        public PlayersGameViewModelItem()
        {
            Properties = new List<PlayerPropertiesGameViewModelItem>();
        }
    }


    public class PlayerPropertiesGameViewModelItem
    {
        public IEnumerable<CardGameViewModelItem> Hand { get; set; }
        public int Score { get; set; }

        public int? PlayerId { get; set; }

        public int Round_Id { get; set; }

        public PlayerPropertiesGameViewModelItem()
        {
            Hand = new List<CardGameViewModelItem>();
        }
    }





}

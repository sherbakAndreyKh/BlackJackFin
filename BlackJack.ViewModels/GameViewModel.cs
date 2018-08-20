using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Participant;
using BlackJack.Entities;


namespace BlackJack.ViewModels
{
    public class GameViewModel
    {
        public Dealer Dealer { get; set; }
        public Player Player { get; set; }

        public List<Bot> Bots { get; set; }

        public List<Card> Cards { get; set; }

        public GameViewModel()
        {
            Bots = new List<Bot>();
            Cards = new List<Card>();
        }
    }
}

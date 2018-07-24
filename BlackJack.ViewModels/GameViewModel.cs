using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.Entities.Participant;

namespace BlackJack.ViewModels
{
    public class GameViewModel
    {
        public IEnumerable<Card> CardDeck { get; set; }
        public Player Player { get; set; }
        public Dealer Dealer { get; set; }
        public IEnumerable<Bot> Bots;
    }
}

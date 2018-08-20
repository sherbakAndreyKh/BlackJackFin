using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities.Participant
{
    public class Bot : MainEntity
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public ICollection<Card> Hand { get; set; }

        public Bot()
        {
            Hand = new List<Card>();
        }
    }
}

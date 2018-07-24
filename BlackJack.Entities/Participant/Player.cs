using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.History;

namespace BlackJack.Entities.Participant
{
    public class Player : MainEntity
    {
        public string Name { get; set; }

        public string Score { get; set; }

        public ICollection<Game> Games { get; set; }

        public Player()
        {
            Games = new List<Game>();
        }
    }
}

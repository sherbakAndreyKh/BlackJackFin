using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities.History
{
   public class Round : MainEntity
    {

        public string Winner { get; set; }
        public int NumberOfRound { get; set; }

        public List<Player> Players { get; set; }

        public int? GameId { get; set; }
        public virtual Game Game { get; set; }

        public Round()
        {
            Players = new List<Player>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities.History
{
    public class Game : MainEntity
    {
        public int AmountPlayers { get; set; }

        public virtual ICollection<Round> Rounds { get; set; }

        public Game()
        {
            Rounds = new List<Round>();
        }
    }
}

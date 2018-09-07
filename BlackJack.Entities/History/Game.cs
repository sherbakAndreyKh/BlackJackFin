using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
namespace BlackJack.Entities.History
{
    public class Game : MainEntity
    {
        public int AmountPlayers { get; set; }
        public int NumberGame { get; set; }

        public int? PlayerId { get; set; }
        public Player Player { get; set; }
        
        public virtual ICollection<Round> Rounds { get; set; }

        public Game()
        {
            Rounds = new List<Round>();
        }
    }
}

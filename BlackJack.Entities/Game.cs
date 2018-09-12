using System.Collections.Generic;

namespace BlackJack.Entities
{
    public class Game : BaseEntity
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

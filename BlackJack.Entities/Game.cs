using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.Entities
{
    [Table("Game")]
    public class Game : BaseEntity
    {
        public int AmountPlayers { get; set; }
        public long NumberGame { get; set; }

        public long PlayerId { get; set; }
        //public Player Player { get; set; }

        //public virtual ICollection<Round> Rounds { get; set; }

        //public Game()
        //{
        //    Rounds = new List<Round>();
        //}
    }
}

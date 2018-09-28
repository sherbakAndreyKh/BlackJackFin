using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.Entities
{
    [Table("Round")]
   public class Round : BaseEntity
    {
        public string Winner { get; set; }
        public int WinnerScore { get; set; }
        public long NumberRound { get; set; }

        public long GameId { get; set; }
        //public virtual Game Game { get; set; }

        //public virtual ICollection<PlayerRoundHand> PlayerHands { get; set; }

        //public Round()
        //{
        //    PlayerHands = new List<PlayerRoundHand>();
        //}
    }
}

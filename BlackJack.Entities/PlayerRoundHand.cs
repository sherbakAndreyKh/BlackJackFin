using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.Entities
{
    [Table("PlayerRoundHand")]
    public class PlayerRoundHand : BaseEntity
    {
        public virtual ICollection<Card> Hand { get; set; }

        public int Score { get; set; }

        public long PlayerId { get; set; }
        public Player Player { get; set; }

        public long? RoundId { get; set; }
        public virtual Round Round { get; set; }

        public PlayerRoundHand()
        {
            Hand = new List<Card>();
        }
    }
}

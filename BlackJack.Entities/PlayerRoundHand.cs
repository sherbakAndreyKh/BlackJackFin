using System.Collections.Generic;


namespace BlackJack.Entities
{
    public class PlayerRoundHand : BaseEntity
    {
        public virtual ICollection<Card> Hand { get; set; }
        public int Score { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int? RoundId { get; set; }
        public virtual Round Round { get; set; }

        public PlayerRoundHand()
        {
            Hand = new List<Card>();
        }
    }
}

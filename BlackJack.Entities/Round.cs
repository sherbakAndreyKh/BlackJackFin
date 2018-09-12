using System.Collections.Generic;

namespace BlackJack.Entities
{
   public class Round : BaseEntity
    {
        public string Winner { get; set; }
        public int WinnerScore { get; set; }
        public int NumberRound { get; set; }

        public int? GameId { get; set; }
        public virtual Game Game { get; set; }

        public virtual ICollection<PlayerRoundHand> PlayerHands { get; set; }

        public Round()
        {
            PlayerHands = new List<PlayerRoundHand>();
        }
    }
}

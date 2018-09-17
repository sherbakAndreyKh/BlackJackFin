using System.Collections.Generic;

using BlackJack.Entities.Enums;

namespace BlackJack.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public  Roles  Role { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<PlayerRoundHand> Properties { get; set; }

        public Player()
        {
            Games = new List<Game>();
            Properties = new List<PlayerRoundHand>();
        }
    }
}

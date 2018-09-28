using System.Collections.Generic;
using BlackJack.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlackJack.Entities
{
    [Table("Player")]
    public class Player : BaseEntity
    {
        public string Name { get; set; }

        public  Role  Role { get; set; }

        //public virtual ICollection<Game> Games { get; set; }
        //public virtual ICollection<PlayerRoundHand> PlayerRoundHands { get; set; }

        //public Player()
        //{
        //    Games = new List<Game>();
        //    PlayerRoundHands = new List<PlayerRoundHand>();
        //}
    }
}

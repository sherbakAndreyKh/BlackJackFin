using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.History;

namespace BlackJack.Entities
{
    public class PlayerProperties : MainEntity
    {
        public virtual ICollection<CardHistory> Hand { get; set; }
        public int Score { get; set; }

        public int? PlayerId { get; set; }
        public Player player { get; set; }

        public int Round_Id { get; set; }

        public PlayerProperties()
        {
            Hand = new List<CardHistory>();
        }

    }
}

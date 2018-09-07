using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.History;
using BlackJack.Entities.Enums;

namespace BlackJack.Entities
{
    public class Player : MainEntity
    {
        public string Name { get; set; }

        public  Roles  Role { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<PlayerProperties> Properties { get; set; }

        public Player()
        {
            Games = new List<Game>();
            Properties = new List<PlayerProperties>();
        }
    }
}

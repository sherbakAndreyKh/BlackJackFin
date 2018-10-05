using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    public class PlayerRoundHandCards : BaseEntity
    {
        public long PlayerRoundHandId { get; set; }
        public long CardId { get; set; }
    }
}

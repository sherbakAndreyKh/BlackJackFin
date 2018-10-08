using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.Entities
{
    [Table("Game")]
    public class Game : BaseEntity
    {
        public int PlayersAmount { get; set; }
        public long GameNumber { get; set; }

        public long PlayerId { get; set; }
    }
}

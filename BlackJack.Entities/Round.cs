using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.Entities
{
    [Table("Round")]
   public class Round : BaseEntity
    {
        public string Winner { get; set; }
        public int WinnerScore { get; set; }
        public long RoundNumber { get; set; }

        public long GameId { get; set; }
    }
}

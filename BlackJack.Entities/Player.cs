using System.Collections.Generic;
using BlackJack.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.Entities
{
    [Table("Player")]
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public  PlayerRole  Role { get; set; }
    }
}

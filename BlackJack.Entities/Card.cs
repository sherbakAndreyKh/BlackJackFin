using System.ComponentModel.DataAnnotations.Schema;
using BlackJack.Entities.Enums;

namespace BlackJack.Entities
{
    [Table("Card")]
    public class Card : BaseEntity
    {
        public CardName Name { get; set; }
        public CardSuit Suit { get; set; }//TODO: change to enum +
        public CardValue Value { get; set; }
        public long PlayerRoundHandId { get; set; }

        public Card()
        {
        }       
    }
}

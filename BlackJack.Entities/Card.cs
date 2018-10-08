using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.Entities
{
    [Table("Card")]
    public class Card : BaseEntity
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public string ImgPath { get; set; }

        public Card()
        {
        }

        public Card(string name, string suit, int value, string imgpath)
        {
            Name = name;
            Suit = suit;
            Value = value;
            ImgPath = imgpath;   
        }
    }
}

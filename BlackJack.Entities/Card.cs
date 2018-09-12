using System.Collections.Generic;

namespace BlackJack.Entities
{
    public class Card : BaseEntity
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }
        public string ImgPath { get; set; }

        public virtual ICollection<PlayerRoundHand> Hands { get; set; }

        public Card() {
            Hands = new List<PlayerRoundHand>();
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

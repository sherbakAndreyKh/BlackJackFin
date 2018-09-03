using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.History;

namespace BlackJack.Entities
{
    public class Card : MainEntity
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }

        public string ImgPath { get; set; }

        public virtual ICollection<PlayerProperties> Hands { get; set; }


        public Card() {
            Hands = new List<PlayerProperties>();
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

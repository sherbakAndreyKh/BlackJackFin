using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    public class Card : MainEntity
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }

        public string ImgPath { get; set; }

        public Card() { }

        public Card(string name, string suit, int value, string imgpath)
        {
            Name = name;
            Suit = suit;
            Value = value;
            ImgPath = imgpath;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal class Card
    {
        public string suit;
        public string value;
        public int points;
        //public string Suit { get => suit; set => suit = value; }
        //public int Value { get => value; set => this.value = value; }
        //public int Points { get => points; set => points = value; }

        public Card(string suit,string value,int points) 
        {
            this.suit = suit;
            this.value = value;
            this.points = points;
        }
    }
}

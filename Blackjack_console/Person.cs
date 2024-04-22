using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal class Person:Player
    {
        public CardStack secondHand;

        public Person(CardStack hand, CardStack secondHand,int currentPoints, int money):base(hand,currentPoints,money)
        {
            this.secondHand = secondHand;    
        }
    }
}

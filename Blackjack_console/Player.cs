using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal class Player
    {
        public CardStack hand;
        public int currentPoints;

        public Player()
        {
            hand = new CardStack();
            currentPoints = 5000;
        }
    }
}

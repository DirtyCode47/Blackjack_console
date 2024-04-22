using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal class Computer : Player
    {
        public Computer(CardStack hand, int currentPoints, int money) : base(hand, currentPoints, money)
        {
        }
    }
}

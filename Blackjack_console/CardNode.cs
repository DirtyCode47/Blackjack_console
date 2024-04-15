using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal class CardNode
    {
        public Card card;
        public CardNode? nextCardNode;

        public CardNode(Card card)
        {
            this.card = card;
            nextCardNode = null;
        }
    }
}

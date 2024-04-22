using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal class CardStack
    {
        public CardNode? headCardNode;
        public int count;
        public CardStack()
        {
            headCardNode = null;
            count = 0;
        }

        public void Push(Card newCard)
        {
            var newCardNode = new CardNode(newCard);

            newCardNode.nextCardNode = headCardNode;
            headCardNode = newCardNode;

            count++;
        }

        public Card Pop()
        {
            if (count == 0) throw new Exception("Стэк пустой");

            Card poppedCard = headCardNode.card;
            headCardNode = headCardNode.nextCardNode;

            count--;

            return poppedCard;
        }

        public void AddByIndex(int index, Card newCard)
        {
            if (index < 0 || index > 51 || index>count) throw new Exception("Невозможный индекс");

            var newCardNode = new CardNode(newCard);

            if (index == 0)
            {
                newCardNode.nextCardNode = headCardNode;
                headCardNode = newCardNode;

                count++;

                return;
            }

            var tempCardNode = headCardNode;

            if (index == count)
            {
                while (tempCardNode.nextCardNode != null) 
                {
                    tempCardNode = tempCardNode.nextCardNode;
                }

                tempCardNode.nextCardNode = newCardNode;
                count++;

                return;
            }


            for(int i=0; i<index-1;i++)
            {
                tempCardNode = tempCardNode.nextCardNode;
            }

            var tempCardNodeNext = tempCardNode.nextCardNode;
            tempCardNode.nextCardNode = newCardNode;
            newCardNode.nextCardNode = tempCardNodeNext;

            count++;
        }

        public Card RemoveByIndex(int index)
        {
            if (index < 0 || index > 51 || index > count) throw new Exception("Невозможный индекс");

            if (count == 0) throw new Exception("Стэк пустой");

            CardNode tempCardNode = headCardNode;
            Card removedCard = null;

            if (index == 0)
            {
                removedCard = headCardNode.card;
                headCardNode = headCardNode.nextCardNode;

                count--;

                return removedCard;
            }

            for(int i = 0;i<index-1;i++)
            {
                tempCardNode = tempCardNode.nextCardNode;
            }

            removedCard = tempCardNode.nextCardNode.card;
            tempCardNode.nextCardNode = tempCardNode.nextCardNode.nextCardNode;
            count--;

            return removedCard;
        }


        public (bool isAcesExist, int amountOfAces) IsAcesExist()
        {
            var tempCardNode = this.headCardNode;
            int amountOfAces = 0;
            bool isAcesExist = false;

            while (tempCardNode != null)
            {
                if(tempCardNode.card.value == "Туз")
                {
                    amountOfAces++;
                }
                tempCardNode = tempCardNode.nextCardNode;
            }

            if(amountOfAces>0)
            {
                isAcesExist = true;
            }

            return (isAcesExist,amountOfAces);
        }

        public void SetAllAcesPointsToOne()
        {
            var tempCardNode = this.headCardNode;

            while (tempCardNode != null)
            {
                if (tempCardNode.card.value == "Туз")
                {
                    tempCardNode.card.points=1;
                }
                tempCardNode = tempCardNode.nextCardNode;
            }
        }

        public void SetAllAcesPointsToEleven()
        {
            var tempCardNode = this.headCardNode;

            while (tempCardNode != null)
            {
                if (tempCardNode.card.value == "Туз")
                {
                    tempCardNode.card.points = 11;
                }
                tempCardNode = tempCardNode.nextCardNode;
            }
        }
        //public int GetAmountOfCards()
        //{
        //    var tempCardNode = this.headCardNode;
        //    int amountOfCards = 0;

        //    while (tempCardNode != null)
        //    {
        //        amountOfCards++;
        //        tempCardNode = tempCardNode.nextCardNode;
        //    }

        //    return amountOfCards;
        //}
    }
}

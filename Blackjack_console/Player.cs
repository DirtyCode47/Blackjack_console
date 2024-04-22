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
        public int money;
        public int currentPoints;

        //public Player()
        //{
        //    hand = new CardStack();
        //    money = 5000;
        //    currentPoints = 0;
        //}
        public Player(CardStack hand, int currentPoints,int money)
        {
            this.hand = hand;
            this.currentPoints = currentPoints;
            this.money = money;
        }

        public int GetAmountOfPoints()
        {
            var tempCardNode = hand.headCardNode;
            int amountOfPoints = 0;

            if (hand.count > 2)
            {
                (bool isAcesExist, int amountOfAces) = hand.IsAcesExist();

                while (tempCardNode != null)
                {
                    amountOfPoints += tempCardNode.card.points;
                    tempCardNode = tempCardNode.nextCardNode;
                }

                if (isAcesExist && amountOfPoints > 21)
                {
                    //amountOfPoints -= amountOfAces * 10;
                    //hand.SetAllAcesPointsToOne();
                    amountOfPoints = 0;
                    hand.SetAllAcesPointsToOne();

                    var tempCardNode2 = hand.headCardNode;
                    while (tempCardNode2 != null)
                    {
                        amountOfPoints += tempCardNode2.card.points;
                        tempCardNode2 = tempCardNode2.nextCardNode;
                    }
                }
                return amountOfPoints;
            }

            while (tempCardNode != null)
            {
                amountOfPoints += tempCardNode.card.points;
                tempCardNode = tempCardNode.nextCardNode;
            }


            return amountOfPoints;
        }

        public void AddMoney(int sumOfMoney)
        {
            this.money += sumOfMoney;
        }
        public void TakeMoney(int sumOfMoney)
        {
            this.money -= sumOfMoney;
        }
    }
}

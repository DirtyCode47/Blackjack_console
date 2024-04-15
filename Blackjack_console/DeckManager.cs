using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal static class DeckManager
    {
        public static CardStack CreateDeck()
        {
            var cardStack = new CardStack();

            string[] suits = { "Бубны", "Черви", "Пики", "Трефы" };

            string[] values = { "Двойка","Тройка", "Четверка", "Пятерка", "Шестерка", "Семерка", "Восьмерка", "Девятка",
                "Десятка", "Валет", "Дама", "Король", "Туз"};

            int[] points = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

            foreach (var suit in suits)
            {
                for (int i = 0; i < 13; i++)
                {
                    cardStack.Push(new Card(suit, values[i], points[i]));
                }
            }
            return cardStack;
        }

        public static void ShuffleDeck(CardStack cardStack)
        {
            var rnd = new Random();

            for (int i = 0; i < 10000; i++)
            {
                Card card = cardStack.Pop();


                cardStack.AddByIndex(rnd.Next(0, 51), card);
            }




            
        }
    }
}

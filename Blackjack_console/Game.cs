using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal class Game
    {
        private Player person;
        private Player computer;
        private CardStack deck;
       

        public Game()
        {
            person = new Player(new CardStack(),5000);
            computer = new Player(new CardStack(), 1000000);
            deck = DeckManager.CreateDeck();
        }
        public void Run()
        {
            
            DeckManager.ShuffleDeck(deck);



            var currentCard = deck.headCardNode;
            while (currentCard != null)
            {
                Console.WriteLine($"Масть: {currentCard.card.suit}, Значение: {currentCard.card.value}, Очки: {currentCard.card.points}");
                currentCard = currentCard.nextCardNode;
            }

            Console.WriteLine("\n\n\n");


            computer.hand.Push(deck.Pop());
            computer.hand.Push(deck.Pop());

            Console.WriteLine("Карты крупье:");
            var currentCard2 = computer.hand.headCardNode;
            while (currentCard2 != null)
            {
                Console.WriteLine($"Масть: {currentCard2.card.suit}, Значение: {currentCard2.card.value}, Очки: {currentCard2.card.points}");
                currentCard2 = currentCard2.nextCardNode;
            }

            Console.WriteLine("\n\n\n");


            person.hand.Push(deck.Pop());
            person.hand.Push(deck.Pop());
            person.hand.Push(deck.Pop());
            person.hand.Push(deck.Pop());

            Console.WriteLine("Карты игрока:");
            var currentCard3 = person.hand.headCardNode;
            while (currentCard3 != null)
            {
                Console.WriteLine($"Масть: {currentCard3.card.suit}, Значение: {currentCard3.card.value}, Очки: {currentCard3.card.points}");
                currentCard3 = currentCard3.nextCardNode;
            }

            Console.WriteLine("\n\n\n\n");

            var currentCard4 = deck.headCardNode;
            while (currentCard4 != null)
            {
                Console.WriteLine($"Масть: {currentCard4.card.suit}, Значение: {currentCard4.card.value}, Очки: {currentCard4.card.points}");
                currentCard4 = currentCard4.nextCardNode;
            }
        }
    }
}

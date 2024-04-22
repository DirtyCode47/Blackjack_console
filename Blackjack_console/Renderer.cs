using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal static class Renderer
    {
        public static void PrintBetScreen(Game game)
        {
            Console.Clear();

            Console.Write($"Введите четную ставку больше нуля и в рамках вашего баланса({game.person.money}): ");
        }

        public static void PrintWrongBetScreen(Game game)
        {
            Console.Clear();

            Console.Write($"Вы ввели некорректное значение ставки. Введите четную ставку больше нуля и в рамках вашего баланса({game.person.money}): ");
        }

        public static void PrintBeginOrMiddleRound(Game game)
        {
            Console.Clear();



            //var currentCard = game.deck.headCardNode;
            //while (currentCard != null)
            //{
            //    Console.WriteLine($"Масть: {currentCard.card.suit}, Значение: {currentCard.card.value}, Очки: {currentCard.card.points}");
            //    currentCard = currentCard.nextCardNode;
            //}

            //Console.WriteLine("\n\n\n");




            //Console.WriteLine("Карты крупье:");
            //var currentCard2 = game.computer.hand.headCardNode;
            //while (currentCard2 != null)
            //{
            //    Console.WriteLine($"Масть: {currentCard2.card.suit}, Значение: {currentCard2.card.value}, Очки: {currentCard2.card.points}");
            //    currentCard2 = currentCard2.nextCardNode;
            //}

            //Console.WriteLine("\n\n\n");

            Console.WriteLine($"Баланс крупье: {game.computer.money}");
            Console.WriteLine("Открытая карта крупье: ");
            var tempСroupierCard = game.computer.hand.headCardNode.card;
            Console.WriteLine($"Масть: {tempСroupierCard.suit}, Значение: {tempСroupierCard.value}, Очки: {tempСroupierCard.points}");

            Console.WriteLine("\n\n");

            PrintAllCards(game.person);
            //Console.WriteLine("Карты игрока:");
            //var tempPlayerCard = game.person.hand.headCardNode;

            //while (tempPlayerCard != null)
            //{
            //    Console.WriteLine($"Масть: {tempPlayerCard.card.suit}, Значение: {tempPlayerCard.card.value}, Очки: {tempPlayerCard.card.points}");
            //    tempPlayerCard = tempPlayerCard.nextCardNode;
            //}


            //ПРЕДУСМОТРЕТЬ БЛЭКДЖЕК


            Console.WriteLine("\n\n");
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine();
            Console.WriteLine("Q - Взять карту");
            Console.WriteLine("W - Просто играем!");
            Console.WriteLine("E - Даббл");
            Console.WriteLine("R - Сплит");
            Console.WriteLine("T - Суррендер");
            Console.WriteLine("Y - Страховка");


            //Console.WriteLine("\n\n\n\n");

            //var currentCard4 = game.deck.headCardNode;
            //while (currentCard4 != null)
            //{
            //    Console.WriteLine($"Масть: {currentCard4.card.suit}, Значение: {currentCard4.card.value}, Очки: {currentCard4.card.points}");
            //    currentCard4 = currentCard4.nextCardNode;
            //}
        }

        public static void PrintPickModeMiddleRound(Game game)
        {
            Console.Clear();
            PrintAllCards(game.computer);
            Console.WriteLine("\n\n");

            PrintAllCards(game.person);

        }
        public static void PrintPickModeEndRound(Game game)
        {
            Console.Clear();
            PrintAllCards(game.computer);
            Console.WriteLine("\n\n");

            PrintAllCards(game.person);
            Console.WriteLine("\n");

            Console.WriteLine(game.isPersonWinner?"Победил игрок!":"Победил крупье!");
            Console.WriteLine("\nНажмите 1 чтобы продолжить или 2 чтобы закончить сессию.");
        }

        private static void PrintAllCards<T>(T player) where T : Player
        {
            string amountOfMoney = (player is Person) ? $"Баланс игрока: {player.money}" : $"Баланс Крупье: {player.money}";
            string article = (player is Person) ? "Карты игрока:" : "Карты крупье:";
            var tempPlayerCard = player.hand.headCardNode;

            Console.WriteLine(amountOfMoney);
            Console.WriteLine(article);
            
            while (tempPlayerCard != null)
            {
                Console.WriteLine($"Масть: {tempPlayerCard.card.suit}, Значение: {tempPlayerCard.card.value}, Очки: {tempPlayerCard.card.points}");
                tempPlayerCard = tempPlayerCard.nextCardNode;
            }
        }
    }
}

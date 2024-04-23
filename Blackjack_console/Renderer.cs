using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal static class Renderer
    {
        public static async void PrintBetScreen(Game game)
        {
            Console.Clear();

            for (int i = 1; i < 1000000; i++)
            {
                if (!File.Exists($"Game{i}.txt"))
                {
                    using (StreamWriter writer = new StreamWriter($"Game{i}.txt", true))
                    {
                        await writer.WriteLineAsync($"Введите четную ставку больше нуля и в рамках вашего баланса({game.person.money}): ");
                        await writer.WriteLineAsync("\n");
                    }
                    break;
                }
            }


            Console.Write($"Введите четную ставку больше нуля и в рамках вашего баланса({game.person.money}): ");
        }

        public static async void PrintWrongBetScreen(Game game)
        {
            Console.Clear();

            for (int i = 1; i < 1000000; i++)
            {
                if (!File.Exists($"Game{i}.txt"))
                {
                    using (StreamWriter writer = new StreamWriter($"Game{i - 1}.txt", true))
                    {
                        await writer.WriteAsync($"Вы ввели некорректное значение ставки. Введите четную ставку больше нуля и в рамках вашего баланса({game.person.money}): ");
                    }
                    break;
                }
            }

            Console.Write($"Вы ввели некорректное значение ставки. Введите четную ставку больше нуля и в рамках вашего баланса({game.person.money}): ");
        }

        public static async void PrintAdditionalInfoInFile(string str)
        {
            for (int i = 1; i < 1000000; i++)
            {
                if (!File.Exists($"Game{i}.txt"))
                {
                    using (StreamWriter writer = new StreamWriter($"Game{i - 1}.txt", true))
                    {
                        await writer.WriteLineAsync(str);
                        await writer.WriteLineAsync("\n");
                    }
                    break;
                }
            }
        }

        public static async void PrintBeginOrMiddleRound(Game game)
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


            for (int i = 1; i < 1000000; i++)
            {
                if (!File.Exists($"Game{i}.txt"))
                {
                    using (StreamWriter writer = new StreamWriter($"Game{i - 1}.txt", true))
                    {
                        await writer.WriteLineAsync($"Баланс крупье: {game.computer.money}");
                        await writer.WriteLineAsync("Открытая карта крупье: ");
                        var tempСroupierCard2 = game.computer.hand.headCardNode.card;
                        await writer.WriteLineAsync($"Масть: {tempСroupierCard2.suit}, Значение: {tempСroupierCard2.value}, Очки: {tempСroupierCard2.points}");
                        await writer.WriteLineAsync("\n\n");


                    }
                    break;
                }
            }


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

            for(int i=1;i<1000000;i++)
            {
                if(!File.Exists($"Game{i}.txt"))
                {
                    using (StreamWriter writer = new StreamWriter($"Game{i-1}.txt", true))
                    {
                        await writer.WriteLineAsync("\n\n");
                        await writer.WriteLineAsync("Что вы хотите сделать?");
                        await writer.WriteLineAsync();
                        await writer.WriteLineAsync("Q - Взять карту");
                        await writer.WriteLineAsync("W - Просто играем!");
                        await writer.WriteLineAsync("E - Даббл");
                        await writer.WriteLineAsync("R - Сплит");
                        await writer.WriteLineAsync("T - Суррендер");
                        await writer.WriteLineAsync("Y - Страховка");

                        await writer.WriteLineAsync("\n");
                    }
                    break;
                }
            }

            

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
        public static async void PrintPickModeEndRound(Game game)
        {
            Console.Clear();
            PrintAllCards(game.computer);
            Console.WriteLine("\n\n");

            PrintAllCards(game.person);
            Console.WriteLine("\n");

            switch (game.isPersonWinner)
            {
                case IsPersonWinner.Win:
                    for (int i = 1; i < 1000000; i++)
                    {
                        if (!File.Exists($"Game{i}.txt"))
                        {
                            using (StreamWriter writer = new StreamWriter($"Game{i - 1}.txt", true))
                            {
                                
                                await writer.WriteLineAsync("Победил игрок!");
                                
                                await writer.WriteLineAsync("\n");
                            }
                            break;
                        }
                    }
                    Console.WriteLine("Победил игрок!");
                    break;
                case IsPersonWinner.Draw:
                    for (int i = 1; i < 1000000; i++)
                    {
                        if (!File.Exists($"Game{i}.txt"))
                        {
                            using (StreamWriter writer = new StreamWriter($"Game{i - 1}.txt", true))
                            {

                                await writer.WriteLineAsync("Ничья!");

                                await writer.WriteLineAsync("\n");
                            }
                            break;
                        }
                    }
                    Console.WriteLine("Ничья!");
                    break;
                case IsPersonWinner.Lose:
                    for (int i = 1; i < 1000000; i++)
                    {
                        if (!File.Exists($"Game{i}.txt"))
                        {
                            using (StreamWriter writer = new StreamWriter($"Game{i - 1}.txt", true))
                            {

                                await writer.WriteLineAsync("Победил крупье!");

                                await writer.WriteLineAsync("\n");
                            }
                            break;
                        }
                    }
                    Console.WriteLine("Победил крупье!");
                    break;
            }

            Console.WriteLine("\nНажмите 1 чтобы продолжить или 2 чтобы закончить сессию.");

        }

        private static async void PrintAllCards<T>(T player) where T : Player
        {
            string amountOfMoney = (player is Person) ? $"Баланс игрока: {player.money}" : $"Баланс Крупье: {player.money}";
            string article = (player is Person) ? "Карты игрока:" : "Карты крупье:";
            var tempPlayerCard = player.hand.headCardNode;


            for (int i = 1; i < 1000000; i++)
            {
                if (!File.Exists($"Game{i}.txt"))
                {
                    using (StreamWriter writer = new StreamWriter($"Game{i - 1}.txt", true))
                    {
                        await writer.WriteLineAsync(amountOfMoney);
                        await writer.WriteLineAsync(article);
                    }
                    break;
                }
            }

            Console.WriteLine(amountOfMoney);
            Console.WriteLine(article);
            
            while (tempPlayerCard != null)
            {
                for (int i = 1; i < 1000000; i++)
                {
                    if (!File.Exists($"Game{i}.txt"))
                    {
                        using (StreamWriter writer = new StreamWriter($"Game{i - 1}.txt", true))
                        {
                            await writer.WriteLineAsync($"Масть: {tempPlayerCard.card.suit}, Значение: {tempPlayerCard.card.value}, Очки: {tempPlayerCard.card.points}");
                        }
                        break;
                    }
                }
                Console.WriteLine($"Масть: {tempPlayerCard.card.suit}, Значение: {tempPlayerCard.card.value}, Очки: {tempPlayerCard.card.points}");
                tempPlayerCard = tempPlayerCard.nextCardNode;
            }
        }
    }
}

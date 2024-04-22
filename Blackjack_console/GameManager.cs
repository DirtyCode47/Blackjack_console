using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal static class GameManager
    {
        public static void UpdateGame(Game game)
        {
            Renderer.PrintBetScreen(game);

            bool correctBet = false;
            int bet;
            do
            {
                bet = Convert.ToInt32(Console.ReadLine());

                if (bet < 0 || bet % 2 == 1 || bet > game.person.money)
                {
                    Renderer.PrintWrongBetScreen(game);
                    continue;
                }

                correctBet = true;

            } while (!correctBet);

            game.person.hand.Push(game.deck.Pop());
            game.person.hand.Push(game.deck.Pop());

            game.computer.hand.Push(game.deck.Pop());
            game.computer.hand.Push(game.deck.Pop());

            Renderer.PrintBeginOrMiddleRound(game);

            
            int amountOfPersonPoints = game.person.GetAmountOfPoints();
            

            if (amountOfPersonPoints == 21) //блэкджек
            {
                if(game.computer.GetAmountOfPoints() == 21)
                {
                    Thread.Sleep(1000);
                    EndTheRound(game, true);
                    return;
                }

                Thread.Sleep(1000);

                int tempMoney = Convert.ToInt32(bet * 1.5);
                game.person.AddMoney(tempMoney);
                game.computer.TakeMoney(tempMoney);

                EndTheRound(game, true);
                return;
            }

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.Q: //взять одну карту
                    game.gameModes.pickMode = true;
                    break;
                case ConsoleKey.W: //Пасс
                    game.gameModes.justPlayMode = true;
                    break;
                case ConsoleKey.E: //Дабл
                    game.gameModes.justPlayMode = true;
                    break;
                case ConsoleKey.R: //Сплит
                    game.gameModes.SplitMode = true;
                    break;
                case ConsoleKey.T: //Суррендер
                    game.gameModes.SurrenderMode = true;
                    break;
                case ConsoleKey.Y: //Страховка
                    game.gameModes.InsuranceMode = true;
                    break;
            }

            if(game.gameModes.pickMode)
            {
                game.person.hand.Push(game.deck.Pop());

                amountOfPersonPoints = game.person.GetAmountOfPoints();

                bool isPass = false;

                while (amountOfPersonPoints < 21 && !isPass)
                {
                    Renderer.PrintBeginOrMiddleRound(game);
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Q: //взять одну карту
                            game.person.hand.Push(game.deck.Pop());
                            break;
                        case ConsoleKey.W: //Пасс
                            isPass = true;
                            break;
                    }
                    amountOfPersonPoints = game.person.GetAmountOfPoints();
                }

                if (amountOfPersonPoints > 21)
                {
                    int tempMoney4 = Convert.ToInt32(bet);
                    game.person.TakeMoney(tempMoney4);
                    game.computer.AddMoney(tempMoney4);
                    EndTheRound(game, false);
                    return;
                }

                int amountOfCompPoints = game.computer.GetAmountOfPoints();

                Thread.Sleep(1000);
                Renderer.PrintPickModeMiddleRound(game);
                Thread.Sleep(1000);

                while (amountOfCompPoints < 17)
                {
                    game.computer.hand.Push(game.deck.Pop());
                    amountOfCompPoints = game.computer.GetAmountOfPoints();
                    Renderer.PrintPickModeMiddleRound(game);

                    Thread.Sleep(1000);
                }

                if (amountOfCompPoints > 21)
                {
                    int tempMoney2 = Convert.ToInt32(bet);
                    game.person.AddMoney(tempMoney2);
                    game.computer.TakeMoney(tempMoney2);
                    EndTheRound(game, true);
                    return;
                }

                if (amountOfPersonPoints < amountOfCompPoints)
                {
                    int tempMoney3 = Convert.ToInt32(bet);
                    game.person.TakeMoney(tempMoney3);
                    game.computer.AddMoney(tempMoney3);
                    EndTheRound(game, false);
                    return;
                }

                int tempMoney = Convert.ToInt32(bet);
                game.person.AddMoney(tempMoney);
                game.computer.TakeMoney(tempMoney);
                EndTheRound(game, true);
                return;

                //Сделать возможность переиграть партию
                //Не забыть сбросить значения тузов до 11
                //добавить ничью
                //Норм обработку блэкджека
            }
        }
        private static void EndTheRound(Game game,bool isPersonWinner)
        {
            //if(isPersonWinner)
            //{
            //    game.person.AddMoney(100);
            //    game.computer.TakeMoney(100);
            //}
            //else
            //{
            //    game.person.TakeMoney(100);
            //    game.computer.AddMoney(100);
            //}

            game.isPersonWinner = isPersonWinner;
            Renderer.PrintPickModeEndRound(game);

            game.person.hand.SetAllAcesPointsToEleven();
            game.computer.hand.SetAllAcesPointsToEleven();

            int personDeckCount = game.person.hand.count; 
            int computerDeckCount = game.computer.hand.count;

            for(int i=0;i<personDeckCount;i++)
            {
                game.deck.Push(game.person.hand.Pop());
            }

            for (int i = 0; i < computerDeckCount; i++)
            {
                game.deck.Push(game.computer.hand.Pop());
            }


            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1: //Продолжить игру
                    game.isGameOver = false;
                    break;
                case ConsoleKey.D2: //Закончить игру
                    game.isGameOver = true;
                    break;
            }
        }
    }
}

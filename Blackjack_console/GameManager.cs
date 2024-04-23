using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal static class GameManager
    {
        public static void StartRound(Game game)
        {
            Renderer.PrintBetScreen(game);

            bool correctBet = false;
            int bet;
            do
            {
                bet = Convert.ToInt32(Console.ReadLine());
                Renderer.PrintAdditionalInfoInFile(bet.ToString());

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
                    EndTheRound(game, IsPersonWinner.Draw);
                    return;
                }

                Thread.Sleep(1000);

                int tempMoney = Convert.ToInt32(bet * 1.5);
                game.person.AddMoney(tempMoney);
                game.computer.TakeMoney(tempMoney);

                EndTheRound(game, IsPersonWinner.Win);
                return;
            }

            bool isCorrectButtonClicked = false;
            

            do
            {

                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Q: //взять одну карту
                        Renderer.PrintAdditionalInfoInFile("Была взята карта");
                        GameModes.pickMode = true;
                        isCorrectButtonClicked = true;
                        GameModes.PlayPickMode(game, bet);
                        break;

                    case ConsoleKey.W: //Пасс
                        Renderer.PrintAdditionalInfoInFile("Игрок сделал пасс");
                        GameModes.justPlayMode = true;
                        isCorrectButtonClicked = true;
                        GameModes.PlayPassMode(game, bet);
                        break;

                    case ConsoleKey.E: //Дабл
                        Renderer.PrintAdditionalInfoInFile("Был выбран дубль");
                        GameModes.justPlayMode = true;
                        isCorrectButtonClicked = true;
                        GameModes.PlayDoubleMode(game, bet);
                        break;

                    case ConsoleKey.R: //Сплит
                        var cardNode1 = game.person.hand.headCardNode;
                        var cardNode2 = game.person.hand.headCardNode.nextCardNode;

                        if(cardNode1.card.points != cardNode2.card.points)
                        {
                            isCorrectButtonClicked = false;
                            break;
                        }
                        GameModes.PlaySplitMode(game,bet);
                        isCorrectButtonClicked = true;

                        Renderer.PrintAdditionalInfoInFile("Был выбран сплит");
                        GameModes.SplitMode = true;
                        break;

                    case ConsoleKey.T: //Суррендер
                        Renderer.PrintAdditionalInfoInFile("Была выбрана сдача");
                        GameModes.SurrenderMode = true;
                        isCorrectButtonClicked = true;
                        GameModes.PlaySurrenderMode(game, bet);
                        break;

                    case ConsoleKey.Y: //Страховка
                        Renderer.PrintAdditionalInfoInFile("Была выбрана страховка");
                        if (game.computer.hand.headCardNode.card.points>=10)
                        {
                            GameModes.InsuranceMode = true;
                            GameModes.PlayInsuranceMode(game, bet);
                            break;
                        }
                        isCorrectButtonClicked = false;
                        break;
                }
            } while (!isCorrectButtonClicked);
            

            //if(game.gameModes.pickMode)
            //{
            //    game.person.hand.Push(game.deck.Pop());

            //    amountOfPersonPoints = game.person.GetAmountOfPoints();

            //    bool isPass = false;

            //    while (amountOfPersonPoints < 21 && !isPass)
            //    {
            //        Renderer.PrintBeginOrMiddleRound(game);
            //        key = Console.ReadKey(true);
            //        switch (key.Key)
            //        {
            //            case ConsoleKey.Q: //взять одну карту
            //                game.person.hand.Push(game.deck.Pop());
            //                break;
            //            case ConsoleKey.W: //Пасс
            //                isPass = true;
            //                break;
            //        }
            //        amountOfPersonPoints = game.person.GetAmountOfPoints();
            //    }

            //    if (amountOfPersonPoints > 21)
            //    {
            //        int tempMoney4 = Convert.ToInt32(bet);
            //        game.person.TakeMoney(tempMoney4);
            //        game.computer.AddMoney(tempMoney4);
            //        EndTheRound(game, false);
            //        return;
            //    }

            //    int amountOfCompPoints = game.computer.GetAmountOfPoints();

            //    Thread.Sleep(1000);
            //    Renderer.PrintPickModeMiddleRound(game);
            //    Thread.Sleep(1000);

            //    while (amountOfCompPoints < 17)
            //    {
            //        game.computer.hand.Push(game.deck.Pop());
            //        amountOfCompPoints = game.computer.GetAmountOfPoints();
            //        Renderer.PrintPickModeMiddleRound(game);

            //        Thread.Sleep(1000);
            //    }

            //    if (amountOfCompPoints > 21)
            //    {
            //        int tempMoney2 = Convert.ToInt32(bet);
            //        game.person.AddMoney(tempMoney2);
            //        game.computer.TakeMoney(tempMoney2);
            //        EndTheRound(game, true);
            //        return;
            //    }

            //    if (amountOfPersonPoints < amountOfCompPoints)
            //    {
            //        int tempMoney3 = Convert.ToInt32(bet);
            //        game.person.TakeMoney(tempMoney3);
            //        game.computer.AddMoney(tempMoney3);
            //        EndTheRound(game, false);
            //        return;
            //    }

            //    int tempMoney = Convert.ToInt32(bet);
            //    game.person.AddMoney(tempMoney);
            //    game.computer.TakeMoney(tempMoney);
            //    EndTheRound(game, true);
            //    return;




                //Сделать возможность переиграть партию
                //Не забыть сбросить значения тузов до 11
                //добавить ничью
                //Норм обработку блэкджека
            //}
        }

        //private static void BeginTheRound(Game game)
        //{
        //    Renderer.PrintBetScreen(game);

        //    bool correctBet = false;
        //    int bet;
        //    do
        //    {
        //        bet = Convert.ToInt32(Console.ReadLine());

        //        if (bet < 0 || bet % 2 == 1 || bet > game.person.money)
        //        {
        //            Renderer.PrintWrongBetScreen(game);
        //            continue;
        //        }

        //        correctBet = true;

        //    } while (!correctBet);

        //    game.person.hand.Push(game.deck.Pop());
        //    game.person.hand.Push(game.deck.Pop());

        //    game.computer.hand.Push(game.deck.Pop());
        //    game.computer.hand.Push(game.deck.Pop());

        //    Renderer.PrintBeginOrMiddleRound(game);
        //}

        

        private static void EndTheRound(Game game,IsPersonWinner isPersonWinner)
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

            if(!GameModes.SplitMode)
            {
                for (int i = 0; i < computerDeckCount; i++)
                {
                    game.deck.Push(game.computer.hand.Pop());
                }
            }
            

            game.isPersonWinner = IsPersonWinner.None;

            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1: //Продолжить игру
                    //if(GameModes.SplitMode)
                    //{
                    //    break;
                    //}
                    game.isGameOver = false;
                    break;
                case ConsoleKey.D2: //Закончить игру
                    //if (GameModes.SplitMode)
                    //{
                    //    break;
                    //}
                    game.isGameOver = true;
                    break;
            }
        }
    }
}

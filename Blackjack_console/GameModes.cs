using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal class GameModes
    {
        public static bool pickMode = false; //Кнопка Q - взять карту
        public static bool justPlayMode = false; //Кнопка W - ничего не делать и играть // пасс
        public static bool doubleMode = false; //Кнопка E - сыграть с удвоением суммы
        public static bool SplitMode = false; //Кнопка R - сплит
        public static bool SurrenderMode = false; //Кнопка T - сдаться и получить половину от ставки
        public static bool InsuranceMode = false; //Кнопка Y - страховка от блэкджека


        public static void PlayPickMode(Game game, int bet)
        {
            game.person.hand.Push(game.deck.Pop());

            int amountOfPersonPoints = game.person.GetAmountOfPoints();

            bool isPass = false;
            bool isDoubleModeAvailable = true;

            bool isCorrectButtonClicked = false;

            while (amountOfPersonPoints < 21 && !isPass && !isCorrectButtonClicked)
            {
                Renderer.PrintBeginOrMiddleRound(game);

                isCorrectButtonClicked = false;

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    
                    case ConsoleKey.Q: //взять одну карту
                        Renderer.PrintAdditionalInfoInFile("Была взята карта");
                        game.person.hand.Push(game.deck.Pop());
                        isCorrectButtonClicked = true;
                        isDoubleModeAvailable = false;
                        break;
                    case ConsoleKey.W: //Пасс
                        Renderer.PrintAdditionalInfoInFile("Игрок сделал пасс");
                        isPass = true;
                        isCorrectButtonClicked = true;
                        break;
                    
                }
                amountOfPersonPoints = game.person.GetAmountOfPoints();
            }

            if (amountOfPersonPoints > 21)
            {
                game.person.TakeMoney(bet);
                game.computer.AddMoney(bet);
                EndTheRound(game, IsPersonWinner.Lose);
                return;
            }

            int amountOfCompPoints = game.computer.GetAmountOfPoints();

            if(amountOfCompPoints == 21)
            {
                game.person.TakeMoney(bet);
                game.computer.AddMoney(bet);
                EndTheRound(game, IsPersonWinner.Lose);
                return;
            }

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
                game.person.AddMoney(bet);
                game.computer.TakeMoney(bet);
                EndTheRound(game, IsPersonWinner.Win);
                return;
            }

            if (amountOfPersonPoints < amountOfCompPoints)
            {
                game.person.TakeMoney(bet);
                game.computer.AddMoney(bet);
                EndTheRound(game, IsPersonWinner.Lose);
                return;
            }

            else if(amountOfPersonPoints > amountOfCompPoints)
            {
                game.person.AddMoney(bet);
                game.computer.TakeMoney(bet);
                EndTheRound(game, IsPersonWinner.Win);
                return;
            }
            //int tempMoney = Convert.ToInt32(bet);
            //game.person.AddMoney(tempMoney);
            //game.computer.TakeMoney(tempMoney);
            EndTheRound(game, IsPersonWinner.Draw);
            return;
        }

        public static void PlayPassMode(Game game, int bet)
        {
            int amountOfPersonPoints = game.person.GetAmountOfPoints();


            int amountOfComputerPoints = game.computer.GetAmountOfPoints();


            if (amountOfComputerPoints == 21)
            {
                game.person.TakeMoney(bet);
                game.computer.AddMoney(bet);
                EndTheRound(game, IsPersonWinner.Lose);
                return;
            }

            Thread.Sleep(1000);
            Renderer.PrintPickModeMiddleRound(game);
            Thread.Sleep(1000);

            while (amountOfComputerPoints < 17)
            {
                game.computer.hand.Push(game.deck.Pop());
                amountOfComputerPoints = game.computer.GetAmountOfPoints();
                Renderer.PrintPickModeMiddleRound(game);

                Thread.Sleep(1000);
            }

            if (amountOfComputerPoints > 21)
            {
                game.person.AddMoney(bet);
                game.computer.TakeMoney(bet);
                EndTheRound(game, IsPersonWinner.Win);
                return;
            }

            if (amountOfPersonPoints>amountOfComputerPoints)
            {
                game.person.AddMoney(bet);
                game.computer.TakeMoney(bet);
                EndTheRound(game, IsPersonWinner.Win);
                return;
            }

            if(amountOfPersonPoints < amountOfComputerPoints)
            {
                game.person.TakeMoney(bet);
                game.computer.AddMoney(bet);
                EndTheRound(game, IsPersonWinner.Lose);
                return;
            }

            EndTheRound(game, IsPersonWinner.Draw);
            return;
        }

        public static void PlayDoubleMode(Game game, int bet)
        {
            int newBet = bet * 2;

            game.person.hand.Push(game.deck.Pop());

            int amountOfPersonPoints = game.person.GetAmountOfPoints();
            if (amountOfPersonPoints > 21)
            {
                game.person.TakeMoney(newBet);
                game.computer.AddMoney(newBet);
                EndTheRound(game, IsPersonWinner.Lose);
                return;
            }

            int amountOfComputerPoints = game.computer.GetAmountOfPoints();

            if (amountOfComputerPoints == 21)
            {
                game.person.TakeMoney(newBet);
                game.computer.AddMoney(newBet);
                EndTheRound(game, IsPersonWinner.Lose);
                return;
            }


            Thread.Sleep(1000);
            Renderer.PrintPickModeMiddleRound(game);
            Thread.Sleep(1000);

            while (amountOfComputerPoints < 17)
            {
                game.computer.hand.Push(game.deck.Pop());
                amountOfComputerPoints = game.computer.GetAmountOfPoints();
                Renderer.PrintPickModeMiddleRound(game);

                Thread.Sleep(1000);
            }

            if (amountOfComputerPoints > 21)
            {
                game.person.AddMoney(bet);
                game.computer.TakeMoney(bet);
                EndTheRound(game, IsPersonWinner.Win);
                return;
            }

            if (amountOfPersonPoints > amountOfComputerPoints)
            {
                game.person.AddMoney(newBet);
                game.computer.TakeMoney(newBet);
                EndTheRound(game, IsPersonWinner.Win);
                return;
            }

            if (amountOfPersonPoints < amountOfComputerPoints)
            {
                game.person.TakeMoney(newBet);
                game.computer.AddMoney(newBet);
                EndTheRound(game, IsPersonWinner.Lose);
                return;
            }

            EndTheRound(game, IsPersonWinner.Draw);
            return;
        }

        public static void PlaySurrenderMode(Game game, int bet)
        {
            game.person.TakeMoney(bet/2);
            game.computer.AddMoney(bet/2);
            EndTheRound(game, IsPersonWinner.Lose);
            return;
        }

        public static void PlayInsuranceMode(Game game, int bet)
        {
            int insurance = bet / 2;

            int amountOfPersonPoints = game.person.GetAmountOfPoints();

            int amountOfComputerPoints = game.computer.GetAmountOfPoints();

            if(amountOfComputerPoints == 21)
            {
                EndTheRound(game, IsPersonWinner.Lose);
                return;
            }

            bool isPass = false;

            while (amountOfPersonPoints < 21 && !isPass)
            {
                Renderer.PrintBeginOrMiddleRound(game);
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Q: //взять одну карту
                        Renderer.PrintAdditionalInfoInFile("Была взята карта");
                        game.person.hand.Push(game.deck.Pop());
                        break;
                    case ConsoleKey.W: //Пасс
                        Renderer.PrintAdditionalInfoInFile("Игрок сделал пасс");
                        isPass = true;
                        break;
                }
                amountOfPersonPoints = game.person.GetAmountOfPoints();
            }

            if (amountOfPersonPoints > 21)
            {
                game.person.TakeMoney(bet+insurance);
                game.computer.AddMoney(bet+insurance);
                EndTheRound(game, IsPersonWinner.Lose);
                return;
            }



            while (amountOfComputerPoints < 17)
            {
                game.computer.hand.Push(game.deck.Pop());
                amountOfComputerPoints = game.computer.GetAmountOfPoints();
                Renderer.PrintPickModeMiddleRound(game);

                Thread.Sleep(1000);
            }

            if (amountOfComputerPoints > 21)
            {
                game.person.AddMoney(bet-insurance);
                game.computer.TakeMoney(bet-insurance);
                EndTheRound(game, IsPersonWinner.Win);
                return;
            }

            if (amountOfPersonPoints > amountOfComputerPoints)
            {
                game.person.AddMoney(bet-insurance);
                game.computer.TakeMoney(bet - insurance);
                EndTheRound(game, IsPersonWinner.Win);
                return;
            }

            if (amountOfPersonPoints < amountOfComputerPoints)
            {
                game.person.TakeMoney(bet+insurance);
                game.computer.AddMoney(bet+insurance);
                EndTheRound(game, IsPersonWinner.Lose);
                return;
            }

            EndTheRound(game, IsPersonWinner.Draw);
            return;
        }

        public static void PlaySplitMode(Game game, int bet) //добавить проверку в pick и других модах на 21 очко, так как в сплит моде 21 очко может выпать впоследствии для рук
        {
            SplitMode = true;
            game.person.secondHand.Push(game.person.hand.Pop());

            game.person.hand.Push(game.deck.Pop());
            game.person.secondHand.Push(game.deck.Pop());

            Renderer.PrintBeginOrMiddleRound(game);


            bool isCorrectButtonClicked = false;

            CardStack tempCardStack = new CardStack();
            //tempCardStack.Push(game.person.secondHand.Pop());
            //tempCardStack.Push(game.person.secondHand.Pop());

            //CardStack tempCardStack2 = new CardStack();
            //temp

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


                    case ConsoleKey.T: //Суррендер
                        Renderer.PrintAdditionalInfoInFile("Была выбрана сдача");
                        GameModes.SurrenderMode = true;
                        isCorrectButtonClicked = true;
                        GameModes.PlaySurrenderMode(game, bet);
                        break;
                }
            } while (!isCorrectButtonClicked);


            game.person.hand.Pop();
            game.person.hand.Pop();
            game.person.hand.Push(game.person.secondHand.Pop());
            game.person.hand.Push(game.person.secondHand.Pop());
            Renderer.PrintBeginOrMiddleRound(game);


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


                    case ConsoleKey.T: //Суррендер
                        Renderer.PrintAdditionalInfoInFile("Была выбрана сдача");
                        GameModes.SurrenderMode = true;
                        isCorrectButtonClicked = true;
                        GameModes.PlaySurrenderMode(game, bet);
                        break;
                }
            } while (!isCorrectButtonClicked);

            SplitMode = false;
        }

        private static void EndTheRound(Game game, IsPersonWinner isPersonWinner)
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
            int personSecondDeckCount = game.person.secondHand.count;
            int computerDeckCount = game.computer.hand.count;


            if (!SplitMode)
            {
                for (int i = 0; i < personDeckCount; i++)
                {
                    game.deck.Push(game.person.hand.Pop());
                }

                for (int i = 0; i < personSecondDeckCount; i++)
                {
                    game.deck.Push(game.person.hand.Pop());
                }

                for (int i = 0; i < computerDeckCount; i++)
                {
                    game.deck.Push(game.computer.hand.Pop());
                }
            }

            




            game.isPersonWinner = IsPersonWinner.None;

            if(!SplitMode)
            {
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
            else
            {
                Renderer.PrintBeginOrMiddleRound(game);
                Thread.Sleep(5000);
                //Console.WriteLine("Введите любую клавишу, чтобы продолжить");
                //Console.ReadKey();
            }
            
        }

        //public static void Play
        //private void EndTheSplitRound(Game game, IsPersonWinner isPersonWinner)
    }
}

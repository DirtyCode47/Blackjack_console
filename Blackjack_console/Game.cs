using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal class Game
    {
        public Person person;
        public Computer computer;
        public CardStack deck;
        public GameModes gameModes;
        public bool isGameOver;
        public bool isFirstHandAvailable;
        public bool isSecondHandAvailable;
        public bool isPersonWinner;
        public Game()
        {
            gameModes = new GameModes();
            person = new Person(new CardStack(),new CardStack(), 0,5000);
            computer = new Computer(new CardStack(),0,1000000);
            deck = DeckManager.CreateDeck();
            isGameOver = false;
            isPersonWinner = false;
            isFirstHandAvailable = true;
            isSecondHandAvailable = false;
        }
        public void Run()
        {
            do
            {
                DeckManager.ShuffleDeck(deck);
                GameManager.UpdateGame(this);

            } while (!isGameOver);
        }
    }
}

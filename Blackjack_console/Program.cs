namespace Blackjack_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Card[] cards =
            //{
            //    new Card("Черви","Тройка",3),
            //    new Card("Черви","Четверка",4),
            //    new Card("Черви","Восьмерка",8),
            //    new Card("Черви","Валет",10),
            //    new Card("Черви","Шестерка",6),
            //    new Card("Черви","Двойка",2)
            //};

            //var cardStack = new CardStack();

            //foreach (Card card in cards) 
            //{
            //    cardStack.Push(card);
            //}


            ////cardStack.AddByIndex(0, new Card("Бубна", "Шестерка", 6));
            ////cardStack.RemoveByIndex(5);
            //cardStack.Pop();

            //var currentCard = cardStack.headCardNode;
            //while (currentCard != null)
            //{
            //    Console.WriteLine($"Масть: {currentCard.card.suit}, Значение: {currentCard.card.value}, Очки: {currentCard.card.points}");
            //    currentCard = currentCard.nextCardNode;
            //}


            var cardStack = new CardStack();

            string[] suits = { "Бубны", "Черви", "Пики", "Трефы" };

            string[] values = { "Двойка","Тройка", "Четверка", "Пятерка", "Шестерка", "Семерка", "Восьмерка", "Девятка",
                "Десятка", "Валет", "Дама", "Король", "Туз"};

            int[] points = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

            foreach(var suit in suits)
            {
                for(int i=0;i<13;i++)
                {
                    cardStack.Push(new Card(suit, values[i], points[i]));
                }
            }

            //var currentCard = cardStack.headCardNode;
            //while (currentCard != null)
            //{
            //    Console.WriteLine($"Масть: {currentCard.card.suit}, Значение: {currentCard.card.value}, Очки: {currentCard.card.points}");
            //    currentCard = currentCard.nextCardNode;
            //}

            var rnd = new Random();

            for(int i=0;i<10000;i++)
            {
                Card card = cardStack.Pop();


                cardStack.AddByIndex(rnd.Next(0, 51), card);
            }




            var currentCard = cardStack.headCardNode;
            while (currentCard != null)
            {
                Console.WriteLine($"Масть: {currentCard.card.suit}, Значение: {currentCard.card.value}, Очки: {currentCard.card.points}");
                currentCard = currentCard.nextCardNode;
            }
        }
    }
}

namespace Blackjack_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card[] cards =
            {
                new Card("Черви","Тройка",3),
                new Card("Черви","Четверка",4),
                new Card("Черви","Восьмерка",8),
                new Card("Черви","Валет",10),
                new Card("Черви","Шестерка",6),
                new Card("Черви","Двойка",2)
            };

            var cardStack = new CardStack();

            foreach (Card card in cards) 
            {
                cardStack.Push(card);
            }


            //cardStack.AddByIndex(0, new Card("Бубна", "Шестерка", 6));
            //cardStack.RemoveByIndex(5);
            cardStack.Pop();

            var currentCard = cardStack.headCardNode;
            while(currentCard!=null)
            {
                Console.WriteLine($"Масть: {currentCard.card.suit}, Значение: {currentCard.card.value}, Очки: {currentCard.card.points}");
                currentCard = currentCard.nextCardNode;
            }
        }
    }
}

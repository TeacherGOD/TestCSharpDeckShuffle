using WebApplication3;
using WebApplication3.Interfaces;

public class ShuffleProvider : IShuffle<Deck>
{
    public Deck ShuffleDeck(Deck deck)
    {
        var random = new Random();
        deck.AllCards=deck.AllCards.OrderBy(_ => random.Next()).ToList();
        return deck;
    }
}

public class ShuffleProviderReal : IShuffle<Deck>
{
    public Deck ShuffleDeck(Deck deck)
    {
        var r = new Random();
        var currentDeck = deck;
        var currentDeckCards = deck.AllCards;
        var cardAmount = currentDeckCards.Count;

        
        int IndexToMove(int max, int maxPercent=20)
        {
            var random = new Random();
            if (maxPercent >= 50)
                throw new ArgumentException($"max Percent can't be 50+");
            var randomPercent = (double) random.Next(maxPercent) / 100;
            var cardsToMove = (int) (max * randomPercent);
            
            return cardsToMove;
        }

        void MakeOneHalfShuffle()
        {
            var plusMinus = new Random().Next(1, 2) == 1 ? -1 : 1;
            var indexToSplitHalf = cardAmount / 2 + IndexToMove(cardAmount)*plusMinus - 1;
            var splitDeck = currentDeckCards.GetRange(indexToSplitHalf, cardAmount - indexToSplitHalf);
            currentDeckCards.RemoveRange(indexToSplitHalf, cardAmount - indexToSplitHalf);
            var indexToInsert = IndexToMove(currentDeckCards.Count);
            currentDeckCards.InsertRange(indexToInsert, splitDeck);
        }

        var countHalfShuffles = r.Next(45,100); 
        for (int i = 0; i < countHalfShuffles; i++)
        {
            MakeOneHalfShuffle();
        }

        return currentDeck;
    }
}

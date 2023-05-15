using WebApplication4.models;

namespace WebApplication4.Interfaces;

public interface IDecks
{
    void DeleteDeck(string name);
    Deck GetDeck(string name);

    string GetAllDecksNames();
    Deck CreateNewDeck(string name, int cardAmount);
    Deck ShuffleDeck(string name);
    public ShufflerChanger Shuffler { get; }
}
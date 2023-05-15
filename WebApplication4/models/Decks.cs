using System.Text;
using WebApplication4.Interfaces;

namespace WebApplication4.models
{
     public class Decks : IDecks
{
    //private List<Deck> Decks { get; } = new();


    public ShufflerChanger Shuffler { get; }

    public Decks(ShufflerChanger shuffler)
    {
        this.Shuffler = shuffler;
    }

    public Dictionary<string,Deck> AllDecksDictionary { get; } = new();


    public void DeleteDeck(string name)
    {
        try
        {
            AllDecksDictionary.Remove(name);
        }
        catch (Exception e)
        {
            throw new ArgumentNullException($"Cant find {name} in Decks.");
        }
    }

    public Deck GetDeck(string name)
    {
        try
        {
            return AllDecksDictionary[name];
        }
        catch (Exception e)
        {
            throw new ArgumentNullException($"Cant find {name} in Decks.");
        }
        
    }

    public string GetAllDecksNames()
    {
        if (AllDecksDictionary.Count == 0)
            return "";
        var stringBuilder = new StringBuilder();
        foreach (var deck in AllDecksDictionary)
        {
           //stringBuilder.Append(deck.Name);
            stringBuilder.AppendFormat("{0}, ",deck.Value.Name);
        }

        stringBuilder.Remove(stringBuilder.Length - 2, 2);
        
        return stringBuilder.ToString();
        

    }

    public Deck CreateNewDeck(string name,int cardAmount=52)
    {
        AllDecksDictionary.Add(name, new Deck(name, cardAmount));
        return AllDecksDictionary[name];
    }

    public Deck ShuffleDeck(string name)
    {

        return Shuffler.CurrentProvider.ShuffleDeck(GetDeck(name));
    }

    public override string ToString()
    {
        return AllDecksDictionary.ToString();
    }
}

}
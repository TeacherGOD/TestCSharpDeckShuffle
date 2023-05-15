﻿using System.Text;
using WebApplication3.Interfaces;

namespace WebApplication3
{
    public class Decks : IDecks
{
    //private List<Deck> Decks { get; } = new();


    public ShufflerChanger Shuffler { get; }

    public Decks(ShufflerChanger shuffler)
    {
        this.Shuffler = shuffler;
    }

    private Dictionary<string,Deck> AllDecksDictionary { get; } = new();


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
            stringBuilder.AppendFormat("{0} ",deck.Value.Name);
        }

        //stringBuilder.Remove(stringBuilder.Length - 1, 1);
        
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

    
}

}
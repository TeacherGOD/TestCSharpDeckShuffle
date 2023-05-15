using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

[ApiController]
[Route("[controller]")]
public class DeckController : ControllerBase
{
    
    //private readonly ShufflerChanger shuffler = new ShufflerChanger();
    private readonly Decks decks = new Decks(new ShufflerChanger());
    
    // GET
    [HttpGet]
    public string Get(string text)
    {
        decks.GetDeck(text);
        return $"GET Some Random {text}";
    }

    [HttpPost]
    public string Post(string text)
    {
        decks.CreateNewDeck(text);
        return $"POST some random ${text}";
    }
    
    [HttpDelete]
    public string Delete(string text)
    {
        decks.DeleteDeck(text);
        return $"DELETE some random ${text}";
    }
    
    [HttpGet]
    public string GetAll()
    {
        decks.GetAllDecksNames();
        return $"GetAll some random ";
    }

    [HttpPut]
    public string Shuffle(string name)
    {
        decks.ShuffleDeck(name);
        return $"I Shuffled {name} deck";
    }

    public string ChangeShuffler(int id)
    {
        decks.Shuffler.ChangeShuffle(id);
        return $"I CHANGE Shuffler by {id}";
    }
}
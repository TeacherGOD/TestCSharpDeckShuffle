using Microsoft.AspNetCore.Mvc;
using WebApplication4.models;

namespace WebApplication4.Controllers;

[ApiController]
[Route("[controller]")]
public class Random : ControllerBase
{


    //List<Friend> friends = new List<Friend>();
    private Decks decks = new(new ShufflerChanger());


    private void Ini()
    {
        
        decks.CreateNewDeck("1");
        decks.CreateNewDeck("2");
        decks.CreateNewDeck("3 Shuffled");
        decks.ShuffleDeck("3 Shuffled");
        decks.CreateNewDeck("4");
    }
    
    
    
    // GET: api/Friend
    [HttpGet]
    public Deck Get(string name)
    {
        Ini();
        return decks.GetDeck(name);
    }
    
    [HttpGet("{id}")]
    public string Get()
    {
        Ini();
        return decks.GetAllDecksNames();
    }
    
    [HttpPost]
    public Decks Post(string name)
    {
        Ini();
        decks.CreateNewDeck(name);
        return decks;
    }
    
    [HttpPut("{id}")]
    public Decks Put(string name)
    {
        Ini();
        decks.ShuffleDeck(name);
        return decks;
    }
    
    
    [HttpDelete("id")]
    public Decks Delete(string name)
    {
        Ini();
        decks.DeleteDeck(name);
        return decks;
    }
    //*/
    private List<Friend> friends = new List<Friend>()
    {
        new Friend(1, "Kindson", "Munonye", "Budapest", DateTime.Today),
        new Friend(2, "Oleander", "Yuba", "Nigeria", DateTime.Today),
        new Friend(3, "Saffron", "Lawrence", "Lagos", DateTime.Today),
        new Friend(4, "Jadon", "Munonye", "Asaba", DateTime.Today),
        new Friend(5, "Solace", "Okeke", "Oko", DateTime.Today)
    };
    
    /*
    // GET: api/Friend
    [HttpGet]
    public List<Friend> Get()
    {
        return friends;
    }
    
    // POST: api/Friend
    [HttpPost]
    public List<Friend> Post([FromBody] Friend friend)
    {
        friends.Add(friend);
        return friends;
    }    
    
    // PUT: api/Friend/5
    [HttpPut("{id}")]
    public List<Friend> Put(int id, [FromBody] Friend friend)
    {
        Friend friendToUpdate = friends.Find(f => f.id == id);
        int index = friends.IndexOf(friendToUpdate);

        friends[index].firstname = friend.firstname;
        friends[index].lastname = friend.lastname;
        friends[index].location = friend.location;
        friends[index].dateOfHire = friend.dateOfHire;

        return friends;
    }
    
    
    
    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public List<Friend> Delete(int id)
    {
        Friend friend = friends.Find(f => f.id == id);
        friends.Remove(friend);
        return friends;
        
        
        
        
    }
    
    */
    
    
    
    
}
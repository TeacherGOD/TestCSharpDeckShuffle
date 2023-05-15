namespace WebApplication3
{
public class Deck
{
    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object obj)
    {
        if (obj != null && obj.GetType() != this.GetType())
            return false;
        var deck = (Deck) obj;
        if (deck != null && deck.Name != Name && deck.AllCards.Count!=AllCards.Count)
            return false;
        return deck != null && AllCards.SequenceEqual(deck.AllCards);
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = (AllCards != null ? AllCards.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ CardAmount;
            return hashCode;
        }
    }

    
    
    
    
    public List<Card> AllCards { get; set; } = new();
    public string Name { get; }
    public int CardAmount { get; }

    public Deck(string name,int cardAmount=52)
    {
        this.CardAmount = cardAmount;
        this.Name = name;
        Initialize();
    }

    private void Initialize()
    {
        var suit = new [] {"Spades", "Hearts", "Diamonds", "Clubs"};
        foreach (var s in suit)
        {
            //Console.WriteLine(suit);
            for (var cardValue = 1; cardValue < CardAmount / suit.Length+1; cardValue++)
            {
                switch (cardValue)
                {
                    case 1:
                        AllCards.Add(new Card($"A {s}"));
                        break;
                    case 11:
                        AllCards.Add(new Card($"J {s}"));
                        break;
                    case 12:
                        AllCards.Add(new Card($"D {s}"));
                        break;
                    case 13:
                        AllCards.Add(new Card($"K {s}"));
                        break;
                    default:
                        AllCards.Add(new Card($"{cardValue} {s}"));
                        break;
                }

                var extraCards = CardAmount % suit.Length;
                for (int i = 0; i < extraCards; i++)
                {
                    AllCards.Add(new Card($"{i} ExtraCard"));
                }
            }
        }
        
    }
}


}
namespace WebApplication3
{
    public class Card
    {
        public Card(string name)
        {
            Name = name;
        }

        private string Name { get; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return Name.Equals(obj);
        }

        protected bool Equals(Card other)
        {
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}
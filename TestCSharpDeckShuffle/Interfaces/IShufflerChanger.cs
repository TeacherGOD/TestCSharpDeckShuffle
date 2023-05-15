
using WebApplication3.models;

namespace WebApplication3.Interfaces;

public interface IShufflerChanger
{
    IShuffle<Deck> CurrentProvider { get; }
    void ChangeShuffle(int id);
}
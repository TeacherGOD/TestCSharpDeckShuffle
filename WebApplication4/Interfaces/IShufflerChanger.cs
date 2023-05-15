
using WebApplication4.models;

namespace WebApplication4.Interfaces;

public interface IShufflerChanger
{
    IShuffle<Deck> CurrentProvider { get; }
    void ChangeShuffle(int id);
}
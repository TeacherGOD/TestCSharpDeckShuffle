

using WebApplication3.Interfaces;

namespace WebApplication3.models;

public class ShufflerChanger : IShufflerChanger
{
    public IShuffle<Deck> CurrentProvider { get; private set; } = new ShuffleProvider();

    public void ChangeShuffle(int id)
    {
        switch (id)
        {
            case 1:
                CurrentProvider = new ShuffleProvider();
                break;
            case 2:
                CurrentProvider = new ShuffleProviderReal();
                break;
            default:
                CurrentProvider = new ShuffleProvider();
                break;
        }
    }
}
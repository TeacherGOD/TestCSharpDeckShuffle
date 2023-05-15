namespace WebApplication4.Interfaces;

public interface IShuffle<T>
    where T:class
{
    T ShuffleDeck(T deck);
}
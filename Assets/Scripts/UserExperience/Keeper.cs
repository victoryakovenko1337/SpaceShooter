public class Keeper<T> where T: Counter, new()
{
    public T Counter => _counter;

    private T _counter;

    public Keeper()
    {
        _counter = new T();
    }
}

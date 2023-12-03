namespace Task2;

public class Repository<T> where T : notnull
{
    public delegate bool Criteria<in T>(T item);

    private readonly List<T> _elements = new();

    public Repository()
    {
    }

    public Repository(IEnumerable<T> elements)
    {
        AddRange(elements);
    }

    public void Add(T item)
    {
        _elements.Add(item);
    }

    public void AddRange(IEnumerable<T> elements)
    {
        foreach (var element in elements) Add(element);
    }

    public IEnumerable<T> Find(Criteria<T> criteria)
    {
        return _elements.Where(e => criteria(e));
    }
}
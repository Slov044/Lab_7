namespace Task3;

public class FunctionCache<TKey, TResult>
{
    private readonly Dictionary<TKey, (DateTime timeAdd, TResult result)> _cache = new();
    private readonly TimeSpan _cacheDuration;

    public FunctionCache(TimeSpan cacheDuration)
    {
        _cacheDuration = cacheDuration;
    }

    public FunctionCache() : this(TimeSpan.MaxValue)
    {
    }

    public TResult Execute(Func<TKey, TResult> function, TKey key)
    {
        if (_cache.TryGetValue(key, out var cachedItem)
            && DateTime.Now - cachedItem.timeAdd < _cacheDuration)
            return cachedItem.Item2;

        var result = function(key);
        _cache[key] = (DateTime.Now, result);
        return result;
    }
}
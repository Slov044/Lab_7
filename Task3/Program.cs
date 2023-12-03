namespace Task3;

public static class Program
{
    private static int _counter;
    private static readonly TimeSpan Delay = TimeSpan.FromSeconds(1);
    private static readonly TimeSpan AfterDelay = Delay.Add(TimeSpan.FromMilliseconds(200));

    public static async Task Main()
    {
        var functionCache = new FunctionCache<string, int>(Delay);

        Console.WriteLine(functionCache.Execute(ComputeLength, "apple"));
        Console.WriteLine(functionCache.Execute(ComputeLength, "apple"));

        await Task.Delay(AfterDelay);

        Console.WriteLine(functionCache.Execute(ComputeLength, "apple"));

        int ComputeLength(string str)
        {
            Console.WriteLine("Computing length of " + str);
            _counter++;
            Console.WriteLine("Count call: " + _counter);
            return str.Length;
        }
    }
}
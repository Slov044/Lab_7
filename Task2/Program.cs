using System.Text;

namespace Task2;

public static class Program
{
    private static void Main()
    {
        Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

        var intRepository = new Repository<int>(new[] { 5, 10, 15 });
        var stringRepository = new Repository<string>(new[] { "apple", "banana", "cherry" });

        var greatThanSeven = intRepository.Find(item => item > 7);
        var startWithA = stringRepository.Find(item => item.StartsWith('a'));

        Print(greatThanSeven);
        Print(startWithA);
    }

    private static void Print<T>(IEnumerable<T> enumerable)
    {
        foreach (var item in enumerable) Console.WriteLine(item);
    }
}
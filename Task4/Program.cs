using System.Text;

namespace Task4;

public static class Program
{
    private static readonly TaskScheduler<string, int> Scheduler = new();

    private static void Main()
    {
        Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;

        while (true)
        {
            Console.Write("Введіть назву завдання: ");
            var taskName = Console.ReadLine();
            if (string.IsNullOrEmpty(taskName)) break;

            var priority = InputInt();
            Scheduler.AddTask(taskName, priority);
        }

        while (Scheduler.TryExecuteNext(ExecutionDelegate))
        {
        }
    }

    private static void ExecutionDelegate(string task)
    {
        Console.WriteLine($"Виконується завдання: {task}");
    }

    private static int InputInt()
    {
        while (true)
        {
            Console.Write("Введіть пріоритет: ");
            if (int.TryParse(Console.ReadLine(), out var priority)) return priority;

            Console.WriteLine("Неправильний формат пріоритету");
        }
    }
}
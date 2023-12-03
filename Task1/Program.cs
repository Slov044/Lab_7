using System.Text;
using Task1;

public static class Program
{
    public static void Main()
    {
        Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

        var intCalculator = new Calculator<int>();

        Calculator<int>.AddDelegate intAdd = (a, b) => a + b;
        Calculator<int>.SubtractDelegate intSubtract = (a, b) => a - b;
        Calculator<int>.MultiplyDelegate intMultiply = (a, b) => a * b;
        Calculator<int>.DivideDelegate intDivide = (a, b) => a / b;

        Console.WriteLine("Calculator<int>");
        Console.WriteLine("Результат додавання: " + intCalculator.Add(5, 3, intAdd));
        Console.WriteLine("Результат віднімання: " + intCalculator.Subtract(5, 3, intSubtract));
        Console.WriteLine("Результат множення: " + intCalculator.Multiply(5, 3, intMultiply));
        Console.WriteLine("Результат ділення: " + intCalculator.Divide(10, 2, intDivide));

        Console.WriteLine("Calculator<double>");
        var doubleCalculator = new Calculator<double>();

        Calculator<double>.AddDelegate doubleAdd = (a, b) => a + b;
        Calculator<double>.SubtractDelegate doubleSubtract = (a, b) => a - b;
        Calculator<double>.MultiplyDelegate doubleMultiply = (a, b) => a * b;
        Calculator<double>.DivideDelegate doubleDivide = (a, b) => a / b;

        Console.WriteLine("Результат додавання: " + doubleCalculator.Add(5.5, 3.3, doubleAdd));
        Console.WriteLine("Результат віднімання: " + doubleCalculator.Subtract(5.5, 3.3, doubleSubtract));
        Console.WriteLine("Результат множення: " + doubleCalculator.Multiply(5.5, 3.3, doubleMultiply));
        Console.WriteLine("Результат ділення: " + doubleCalculator.Divide(10.0, 2.0, doubleDivide));
    }
}
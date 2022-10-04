using System.Diagnostics;
using System.Reflection;

namespace Puzzles;

public static class Program
{
    public static void Main()
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        var puzzles = executingAssembly
            .GetTypes()
            .Where(x => x.IsAssignableTo(typeof(IPuzzle)))
            .Where(x => !x.IsInterface)
            //.Where(x => x.Name.Contains("Day15"));
            .OrderBy(x => x.Name)
            ;
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        foreach (var puzzle in puzzles)
        {
            Console.WriteLine($"Day {puzzle.Name[3..5]}: {puzzle.Name[5..]}");
            var instance = (IPuzzle)executingAssembly.CreateInstance(puzzle.FullName!)!;
            Time(1, () => instance.CalculatePart1());
            Time(2, () => instance.CalculatePart2());
        }
        
        stopwatch.Stop();
        Console.WriteLine("Full run took " + stopwatch.Elapsed);
    }

    private static void Time(int partNumber, Func<object> func)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine(" - part " + partNumber + ": " + func());
        stopwatch.Stop();
        Console.WriteLine("           calculation took " + stopwatch.Elapsed);
    }
}

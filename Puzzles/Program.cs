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
            .OrderBy(x => x.Name)
            .Where(x => x.Name.Contains("Day15"));
            
        foreach (var puzzle in puzzles)
        {
            Console.WriteLine($"Day {puzzle.Name[3..5]}: {puzzle.Name[5..]}");
            var instance = (IPuzzle)executingAssembly.CreateInstance(puzzle.FullName!)!;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(" - Part 1: " + instance.CalculatePart1());
            stopwatch.Stop();
            Console.WriteLine("           calculation took " + stopwatch.Elapsed);
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine(" - Part 2: " + instance.CalculatePart2());
            stopwatch.Stop();
            Console.WriteLine("           calculation took " + stopwatch.Elapsed);
        }
    }
}

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
            .OrderBy(x => x.Name);

        foreach (var puzzle in puzzles)
        {
            Console.WriteLine($"Day {puzzle.Name[3..5]}: {puzzle.Name[5..]}");
            var instance = (IPuzzle)executingAssembly.CreateInstance(puzzle.FullName);
            var (part1, part2) = instance.Calculate();
            Console.WriteLine(" - Part 1: " + part1);
            Console.WriteLine(" - Part 2: " + part2);
        }
    }
}

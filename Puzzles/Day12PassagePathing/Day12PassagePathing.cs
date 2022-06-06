namespace Puzzles.Day12PassagePathing;

public class Day12PassagePathing : IPuzzle
{
    public object CalculatePart1()
    {
        var input = Helpers.ReadInputData(nameof(Day12PassagePathing));
        return CalculatePart1(input);
    }

    public object CalculatePart2()
    {
        var input = Helpers.ReadInputData(nameof(Day12PassagePathing));
        return CalculatePart2(input);
    }

    public static long CalculatePart1(string[] input)
    {
        var pathFinder = new PathFinder(input);
        var results = pathFinder.Part1Paths;
        return results.Count();
    }

    public static long CalculatePart2(string[] input)
    {
        var pathFinder = new PathFinder(input);
        var results = pathFinder.Part2Paths;
        return results.Count();
    }
}

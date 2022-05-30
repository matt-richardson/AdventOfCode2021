namespace Puzzles.Day12PassagePathing;

public class Day12PassagePathing : IPuzzle
{
    public (object answer1, object answer2) Calculate()
    {
        var input = Helpers.ReadInputData(nameof(Day12PassagePathing));

        return (
            CalculatePart1(input),
            CalculatePart2(input)
        );
    }

    public static long CalculatePart1(string[] input)
    {
        var pathFinder = new PathFinder(input);
        var results = pathFinder.Paths;
        return results.Count();
    }

    public static long CalculatePart2(string[] input)
    {
        return 1;
    }
}

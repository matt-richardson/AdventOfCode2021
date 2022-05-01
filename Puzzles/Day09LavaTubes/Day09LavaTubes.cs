namespace Puzzles.Day09LavaTubes;

public class Day09LavaTubes : IPuzzle
{
    public (object answer1, object answer2) Calculate()
    {
        var input = Helpers.ReadInputData(nameof(Day09LavaTubes));

        return (
            CalculatePart1(input),
            CalculatePart2(input)
        );
    }

    public static long CalculatePart1(string[] input)
    {
        var map = new Map(input);
        var lowPoints = map.LowPoints();
        return lowPoints.Sum(x => x.RiskLevel);
    }

    public static long CalculatePart2(string[] input)
    {
        var map = new Map(input);
        return map
            .Basins()
            .OrderByDescending(x => x.Size)
            .Take(3)
            .Product(x => x.Size);
    }
}


using System.Diagnostics;

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
        var parsed = input.Parse().ToArray();
        var lowPoints = parsed.Where(x => x.IsLowPoint).ToArray();
        return lowPoints.Sum(x => x.RiskLevel);
    }

    public static long CalculatePart2(string[] input)
    {
        return 0;
    }
}

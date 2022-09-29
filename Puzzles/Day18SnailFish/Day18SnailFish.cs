
namespace Puzzles.Day18SnailFish;

public class Day18SnailFish : IPuzzle
{
    public object CalculatePart1()
    {
        var input = Helpers.ReadInputData(nameof(Day18SnailFish))
            .Select(x => Number.Parse(x));
        var result = Number.Add(input);
        return result.Magnitude();
    }

    public object CalculatePart2()
    {
        var input = Helpers.ReadInputData(nameof(Day18SnailFish))
            .Select(Number.Parse);
        var result = Number.LargestSum(input);
        return result.Magnitude();
    }
}
namespace Puzzles.Day07Whales;

public class Day07Whales : IPuzzle
{
    public object CalculatePart1()
    {
        var input = Helpers.ReadInputData(nameof(Day07Whales)).First();
        return CalculatePart1(input);
    }

    public object CalculatePart2()
    {
        var input = Helpers.ReadInputData(nameof(Day07Whales)).First();
        return CalculatePart2(input);
    }

    public static long CalculatePart1(string input)
    {
        int FuelUsageCalculator(int[] positions, int candidateTarget)
            => positions.Aggregate(0, (prev, curr) => prev + Math.Abs(candidateTarget - curr));

        var positions = input.Parse();
        var result = positions.CalculateLowestFuelRequirement(FuelUsageCalculator);
        return result.fuelRequirement;
    }

    public static long CalculatePart2(string input)
    {
        int IncrementingFuelUsageCalculator(int candidateTarget, int position) => Enumerable
                .Range(1, Math.Abs(candidateTarget - position))
                .Aggregate(0, (prev, curr) => prev + curr);

        int FuelUsageCalculator(int[] positions, int candidateTarget) => positions
                .Aggregate(0, (prev, position) => prev + IncrementingFuelUsageCalculator(candidateTarget, position));

        var positions = input.Parse();
        var result = positions.CalculateLowestFuelRequirement(FuelUsageCalculator);
        return result.fuelRequirement;
    }
}

namespace Puzzles.Day07Whales;

public static class Day07WhalesExtensionMethods
{
    public static (int target, int fuelRequirement) CalculateLowestFuelRequirement(this int[] enumerable, Func<int[], int, int> fuelCalculator)
    {
        return Enumerable.Range(enumerable.Min(), enumerable.Max())
            .Select(candidateTarget => (
                candidateTarget,
                fuelRequirement: fuelCalculator(enumerable, candidateTarget)
            )).MinBy(x => x.fuelRequirement);
    }

    public static int[] Parse(this string input)
    {
        return input
            .Split(",")
            .Select(int.Parse)
            .ToArray();
    }
}

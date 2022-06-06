namespace Puzzles.Day11DumboOctopus;

public class Day11DumboOctopus : IPuzzle
{
    public object CalculatePart1()
    {
        var input = Helpers.ReadInputData(nameof(Day11DumboOctopus));
        return CalculatePart1(input);
    }

    public object CalculatePart2()
    {
        var input = Helpers.ReadInputData(nameof(Day11DumboOctopus));
        return CalculatePart2(input);
    }

    public static long CalculatePart1(string[] input)
    {
        var octopusGrid = new OctopusGrid(input);
        octopusGrid.Step(100);

        return octopusGrid.FlashCount;
    }

    public static long CalculatePart2(string[] input)
    {
        var octopusGrid = new OctopusGrid(input);
        octopusGrid.StepUntilSynchronized();
        return octopusGrid.StepCount;
    }
}

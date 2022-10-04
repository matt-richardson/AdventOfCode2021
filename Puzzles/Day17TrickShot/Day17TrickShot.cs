namespace Puzzles.Day17TrickShot;

public class Day17TrickShot : IPuzzle
{
    public object CalculatePart1()
    {
        var input = Helpers.ReadInputData(nameof(Day17TrickShot))[0];
        var velocityCalculator = new VelocityCalculator(input);
        var results = velocityCalculator.Calculate().ToArray();
        return results.Max(probe => probe.MaxYPosition);
    }

    public object CalculatePart2()
    {
        var input = Helpers.ReadInputData(nameof(Day17TrickShot))[0];
        var velocityCalculator = new VelocityCalculator(input);
        var results = velocityCalculator.Calculate().ToArray();
        return results.Length;
    }
}
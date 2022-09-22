namespace Puzzles.Day17TrickShot;

public class Day17TrickShot : IPuzzle
{
    private readonly Probe[] results;

    public Day17TrickShot()
    {
        var input = Helpers.ReadInputData(nameof(Day17TrickShot))[0];
        var velocityCalculator = new VelocityCalculator(input);
        this.results = velocityCalculator.Calculate().ToArray();
    }
    public object CalculatePart1()
    {
        return results.Max(probe => probe.MaxYPosition);
    }

    public object CalculatePart2()
    {
        return results.Length;
    }
}
namespace Puzzles.Day17TrickShot;

public class Day17TrickShot : IPuzzle
{
    public object CalculatePart1()
    {
        var input = Helpers.ReadInputData(nameof(Day17TrickShot))[0];
        var velocityCalculator = new VelocityCalculator(input);
        return velocityCalculator.Calculate().Max(probe => probe.MaxYPosition);
    }

    public object CalculatePart2()
    {
        throw new NotImplementedException();
        // var input = Helpers.ReadInputData(nameof(Day17TrickShot))[0];
        // return CalculatePart2(input);
    }
}
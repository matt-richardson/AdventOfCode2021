namespace Puzzles.Day17TrickShot;

public class VelocityCalculator
{
    private readonly TargetArea targetArea;

    public VelocityCalculator(string input)
    {
        targetArea = TargetArea.Parse(input);
    }

    public IEnumerable<Probe> Calculate()
    {
        for (var x = 0; x < 400; x++)
        for (var y = -400; y < 400; y++)
        {
            var velocity = new Velocity(x, y);
            var probe = new Probe(velocity);
            while (!targetArea.HasOvershot(probe))
            {
                probe.Step();
                if (targetArea.IsInTargetArea(probe))
                {
                    yield return probe;
                    break;
                }
            }
        }
    }
}
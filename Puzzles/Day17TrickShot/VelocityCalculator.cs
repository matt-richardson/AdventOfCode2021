using System.Text.RegularExpressions;

namespace Puzzles.Day17TrickShot;

public class VelocityCalculator
{
    private readonly int minX;
    private readonly int maxX;
    private readonly int minY;
    private readonly int maxY;

    public VelocityCalculator(string input)
    {
        //example:
        //target area: x=20..30, y=-10..-5
        var regex = new Regex("target area: x=([-\\d]+)\\.\\.([-\\d]+), y=([-\\d]+)\\.\\.([-\\d]+)");
        var match = regex.Match(input);
        minX = Convert.ToInt32(match.Groups[1].Value);
        maxX = Convert.ToInt32(match.Groups[2].Value);
        minY = Convert.ToInt32(match.Groups[3].Value);
        maxY = Convert.ToInt32(match.Groups[4].Value);
    }

    public IEnumerable<Probe> Calculate()
    {
        for (var x = -500; x < 500; x++)
        for (var y = -500; y < 500; y++)
        {
            var velocity = new Velocity(x, y);
            var probe = new Probe(velocity);
            while (!probe.HasOvershot(minX, maxX, minY, maxY))
            {
                probe.Step();
                if (probe.IsInTargetArea(minX, maxX, minY, maxY))
                {
                    yield return probe;
                    break;
                }
            }
        }
    }
}
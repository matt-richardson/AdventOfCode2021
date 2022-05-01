using System.Diagnostics;

namespace Puzzles.Day09LavaTubes;

[DebuggerDisplay("Size: {Size}")]
public class Basin
{
    private readonly List<Point> points;

    public Basin(List<Point> points)
    {
        this.points = points;
    }

    public int Size => points.Count;
}

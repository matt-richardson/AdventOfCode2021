using System.Diagnostics;

namespace Puzzles.Day12PassagePathing;

[DebuggerDisplay("{ToString()}")]
public class Path
{
    private readonly Stack<Cave> path = new();

    public Path(Path paths, Cave connectedCave)
    {
        foreach (var cave in paths.PopPaths)
            path.Push(cave);
        path.Push(connectedCave);
    }

    public Path(Cave cave)
    {
        path.Push(cave);
    }

    private IEnumerable<Cave> PopPaths => path.ToArray().Reverse();

    public override string ToString() => string.Join(",", path.ToArray().Select(x => x.Name));
}

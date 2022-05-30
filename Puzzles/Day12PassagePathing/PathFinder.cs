namespace Puzzles.Day12PassagePathing;

public class PathFinder
{
    private readonly CaveSystem caveSystem;

    public PathFinder(string[] sampleData)
    {
        caveSystem = sampleData.Parse();
        Paths = FindPaths().ToArray();
    }

    public IEnumerable<Path> Paths { get; set; }

    public IEnumerable<Path> FindPaths()
    {
        foreach (var path in FindPaths(caveSystem.Start, new HashSet<Cave>()))
            yield return new Path(path, caveSystem.Start);
    }

    public IEnumerable<Path> FindPaths(Cave cave, HashSet<Cave> visited)
    {
        visited.Add(cave);
        foreach (var connectedCave in cave.ConnectedCaves)
        {
            if (connectedCave.IsEnd)
            {
                yield return new Path(connectedCave);
            }
            else if (CanVisit(visited, connectedCave))
            {
                foreach (var path in FindPaths(connectedCave, new HashSet<Cave>(visited)))
                    yield return new Path(path, connectedCave);
            }
        }
    }

    private bool CanVisit(HashSet<Cave> visited, Cave connectedCave)
    {
        return connectedCave.IsBigCave || !visited.Contains(connectedCave);
    }
}

using Puzzles.Day12PassagePathing.VisitTrackers;

namespace Puzzles.Day12PassagePathing;

public class PathFinder
{
    private readonly CaveSystem caveSystem;

    public PathFinder(string[] sampleData)
    {
        caveSystem = sampleData.Parse();
        Part1Paths = FindPaths(new Part1VisitTracker()).ToArray();
        Part2Paths = FindPaths(new Part2VisitTracker()).ToArray();
    }

    public IEnumerable<Path> Part1Paths { get; set; }
    public IEnumerable<Path> Part2Paths { get; set; }

    public IEnumerable<Path> FindPaths(IVisitTracker tracker)
    {
        foreach (var path in FindPaths(caveSystem.Start, tracker))
            yield return new Path(path, caveSystem.Start);
    }

    public IEnumerable<Path> FindPaths(Cave cave, IVisitTracker visited)
    {
        visited.Visit(cave);
        foreach (var connectedCave in cave.ConnectedCaves)
        {
            if (connectedCave.IsEnd)
            {
                yield return new Path(connectedCave);
            }
            else if (visited.CanVisit(connectedCave))
            {
                foreach (var path in FindPaths(connectedCave, visited.Clone()))
                    yield return new Path(path, connectedCave);
            }
        }
    }
}

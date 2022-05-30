namespace Puzzles.Day12PassagePathing.VisitTrackers;

public class Part1VisitTracker : IVisitTracker
{
    private readonly HashSet<Cave> visited;

    public Part1VisitTracker()
    {
        visited = new HashSet<Cave>();
    }
    
    private Part1VisitTracker(HashSet<Cave> hashSet)
    {
        visited = new HashSet<Cave>(hashSet);
    }

    public bool CanVisit(Cave cave) => cave.IsBigCave || !visited.Contains(cave);

    public void Visit(Cave cave)
    {
        visited.Add(cave);
    }

    public IVisitTracker Clone() => new Part1VisitTracker(visited);
}

namespace Puzzles.Day12PassagePathing.VisitTrackers;

public class Part2VisitTracker : IVisitTracker
{
    private readonly Dictionary<Cave, int> visited;

    public Part2VisitTracker()
    {
        visited = new Dictionary<Cave, int>();
    }
    
    private Part2VisitTracker(Dictionary<Cave, int> previous)
    {
        visited = new Dictionary<Cave, int>(previous);
    }

    public bool CanVisit(Cave cave)
    {
        if (cave.IsStart)
            return false;
        if (cave.IsBigCave)
            return true;
        if (cave.IsLittleCave)
        {
            if (!visited.ContainsKey(cave))
                return true;
            return visited
                .Where(x => x.Key.IsLittleCave)
                .All(x => x.Value == 1);
        } 
        return false;
    }

    public void Visit(Cave cave)
    {
        if (visited.ContainsKey(cave))
            visited[cave] += 1; 
        else 
            visited.Add(cave, 1);
    }

    public IVisitTracker Clone() => new Part2VisitTracker(visited);
}

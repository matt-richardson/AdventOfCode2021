namespace Puzzles.Day15Chiton;

public class VisitTracker
{
    private readonly HashSet<Cell> visited;

    public VisitTracker()
    {
        visited = new HashSet<Cell>();
    }
    
    private VisitTracker(HashSet<Cell> hashSet)
    {
        visited = new HashSet<Cell>(hashSet);
    }

    public bool CanVisit(Cell cell) => !visited.Contains(cell);

    public void Visit(Cell cell)
    {
        visited.Add(cell);
    }

    public VisitTracker Clone() => new VisitTracker(visited);
}

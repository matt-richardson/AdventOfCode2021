using System.Diagnostics;

namespace Puzzles.Day15Chiton;

[DebuggerDisplay("{ToString()}")]
public class Path
{
    private readonly Stack<Cell> path = new();

    public Path(Path paths, Cell connectedCell)
    {
        foreach (var cell in paths.PopPaths)
            path.Push(cell);
        path.Push(connectedCell);

        var arr = path.ToArray();
        IsComplete = arr.Any(cell => cell.IsEnd) && arr.Any(cell => cell.IsStart);
        Risk = arr.Sum(x => x.Risk);
        RevistsItself = path.ToArray().DistinctBy(cell => (cell.X, cell.Y)).Count() < path.Count;
    }

    public Path(Cell cell)
    {
        path.Push(cell);
        IsComplete = cell.IsEnd && cell.IsStart;
        Risk = cell.Risk;
        RevistsItself = false;
    }

    private IEnumerable<Cell> PopPaths => path.ToArray().Reverse();

    public override string ToString() => string.Join("->", path.ToArray().Select(x => x.ToString()));
    
    public bool IsComplete { get; private set; }
    public int Risk { get; private set; }

    public bool RevistsItself {get ; private set; }
}
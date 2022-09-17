using System.Diagnostics;
using RT.Dijkstra;

namespace Puzzles.Day15Chiton;

[DebuggerDisplay("{ToString()}")]
public class Cell : Node<int, string>
{
    private readonly int x;
    private readonly int y;
    private readonly int risk;
    private Cell? left;
    private Cell? up;
    private Cell? right;
    private Cell? down;
    private IList<Cell> connectedCells;
    
    public Cell(int x, int y, int risk)
    {
        this.x = x;
        this.y = y;
        this.risk = risk;
        connectedCells = new List<Cell>();
    }

    private bool Equals(Cell other)
    {
        return x == other.x && y == other.y && risk == other.risk;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Cell)obj);
    }

    public override bool Equals(Node<int, string> other) 
        => Equals(other as Cell ?? throw new InvalidOperationException());

    public override int GetHashCode() => HashCode.Combine(x, y, risk);
    
    public void Connect(IList<Cell> cells)
    {
        left = cells.FirstOrDefault(cell => cell.x == x - 1 && cell.y == y);
        up = cells.FirstOrDefault(cell => cell.x == x && cell.y == y - 1);
        right = cells.FirstOrDefault(cell => cell.x == x + 1 && cell.y == y);
        down = cells.FirstOrDefault(cell => cell.x == x && cell.y == y + 1);
        connectedCells = (new List<Cell?> { left, up, right, down })
            .Where(cell => cell != null)
            .Cast<Cell>()
            .ToList();
    }

    public bool IsStart => left == null && up == null;

    public override string ToString() => $"{x},{y}";

    public override bool IsFinal => right == null && down == null;

    public override IEnumerable<Edge<int, string>> Edges =>
        connectedCells.Select(toCell => new Edge<int, string>(
            toCell.risk,
            $"{this} to {toCell}",
            toCell));
}
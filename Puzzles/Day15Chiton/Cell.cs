using System.Diagnostics;
using RT.Dijkstra;

namespace Puzzles.Day15Chiton;

[DebuggerDisplay("{ToString()}")]
public class Cell : Node<int, string>
{
    public int X { get; }
    public int Y { get; }
    public int Risk { get; }
    private Cell? left;
    private Cell? up;
    private Cell? right;
    private Cell? down;
    private IEnumerable<Edge<int, string>> edges;

    public Cell(int x, int y, int risk)
    {
        this.X = x;
        this.Y = y;
        this.Risk = risk > 9 ? 1 : risk;
        edges = Array.Empty<Edge<int, string>>();
    }

    private bool Equals(Cell other)
    {
        return X == other.X && Y == other.Y && Risk == other.Risk;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Cell)obj);
    }

    public override bool Equals(Node<int, string> other) 
        => Equals(other as Cell ?? throw new InvalidOperationException());

    public override int GetHashCode() => HashCode.Combine(X, Y, Risk);
    
    public void Connect(IList<Cell> cells)
    {
        left = cells.FirstOrDefault(cell => cell.X == X - 1 && cell.Y == Y);
        up = cells.FirstOrDefault(cell => cell.X == X && cell.Y == Y - 1);
        right = cells.FirstOrDefault(cell => cell.X == X + 1 && cell.Y == Y);
        down = cells.FirstOrDefault(cell => cell.X == X && cell.Y == Y + 1);
        edges = new List<Cell?> { left, up, right, down }
            .Where(cell => cell != null)
            .Cast<Cell>()
            .OrderBy(x => x.Risk)
            .Select(toCell => new Edge<int, string>(toCell.Risk, $"{this} to {toCell}", toCell))
            .ToArray();
    }

    public bool IsStart => left == null && up == null;

    public override string ToString() => $"{X},{Y}";

    public override bool IsFinal => right == null && down == null;

    public override IEnumerable<Edge<int, string>> Edges => edges;
}
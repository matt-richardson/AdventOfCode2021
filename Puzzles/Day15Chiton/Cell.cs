using System.Diagnostics;

[DebuggerDisplay("{ToString()}")]
public class Cell
{
    public Cell(int x, int y, int risk)
    {
        X = x;
        Y = y;
        Risk = risk;
        ConnectedCells = new List<Cell>();
    }

    public int X { get; private set; }
    public int Y { get; private set; }
    public int Risk { get; private set; }
    public Cell? Left { get; private set;}
    public Cell? Up { get; private set;}
    public Cell? Right { get; private set;}
    public Cell? Down { get; private set;}

    public void Connect(IList<Cell> cells)
    {
        Left = cells.FirstOrDefault(cell => cell.X == X - 1 && cell.Y == Y);
        Up = cells.FirstOrDefault(cell => cell.X == X && cell.Y == Y - 1);
        Right = cells.FirstOrDefault(cell => cell.X == X + 1 && cell.Y == Y);
        Down = cells.FirstOrDefault(cell => cell.X == X && cell.Y == Y + 1);
        ConnectedCells = (new List<Cell> { Left!, Up!, Right!, Down! }).Where(x => x != null).ToList();
    }

    public IList<Cell> ConnectedCells = new List<Cell>();

    public bool IsEnd => Right == null && Down == null;
    public bool IsStart => Left == null && Up == null;

    public override string ToString() => $"{X},{Y}";
}
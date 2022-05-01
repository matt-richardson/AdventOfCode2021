using System.Diagnostics;
using System.Xml.Xsl;
using NUnit.Framework.Constraints;

namespace Puzzles.Day09LavaTubes;

[DebuggerDisplay("({RowNumber},{ColNumber}): Height {Height}, Risk {RiskLevel}")]
public class Point
{
    public Point(int rowNumber, int colNumber, int height) 
    {
        RowNumber = rowNumber;
        ColNumber = colNumber;
        Height = height;
    }

    public bool IsLowPoint =>
        IsLowerThanPointUp &&
        IsLowerThanPointDown &&
        IsLowerThanPointLeft &&
        IsLowerThanPointRight;

    public int RiskLevel => Height + 1;

    private bool IsLowerThanPointUp => Up == null || Up.Height > Height;
    private bool IsLowerThanPointDown => Down == null || Down.Height > Height;
    private bool IsLowerThanPointLeft => Left == null || Left.Height > Height;
    private bool IsLowerThanPointRight => Right == null || Right.Height > Height;
    public int RowNumber { get; }
    public int ColNumber { get; }
    public int Height { get; }
    private Point? Up { get; set; }
    private Point? Down { get; set; }
    private Point? Left { get; set; }
    private Point? Right { get; set; }

    public Point WithNeighbours(Point? up, Point? down, Point? left, Point? right)
    {
        Up = up;
        Down = down;
        Left = left;
        Right = right;
        return this;
    }

    public Basin GetBasin()
    {
        var seenPoints = new List<Point>();
        var potentials = new Stack<Point>();
        potentials.Push(this);
        do
        {
            var current = potentials.Pop();
            seenPoints.Add(current);
            current.Neighbours()
                .NotNull()
                .Where(point => point.Height < 9)
                .Where(point => !seenPoints.Any(x => x.Equals(point)))
                .Where(point => !potentials.Any(x => x.Equals(point)))
                .ToList()
                .ForEach(neighbour => potentials.Push(neighbour));
        } while (potentials.Any());
        return new Basin(seenPoints);
    }

    private List<Point?> Neighbours() => new() {Up, Down, Left, Right};

#region Equality Comparers
    protected bool Equals(Point other)
    {
        return RowNumber == other.RowNumber && ColNumber == other.ColNumber && Height == other.Height;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Point) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RowNumber, ColNumber, Height);
    }
#endregion
}

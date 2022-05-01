using Microsoft.VisualBasic;

namespace Puzzles.Day09LavaTubes;

public class Map
{
    private readonly IReadOnlyCollection<Point> points;
    private readonly IReadOnlyCollection<Basin> basins;

    record Cell(int Index, int? Left, int? Current, int? Right);
    record Row(int Index, int[]? Up, int[] Current, int[]? Down);
    record RowWithCols(Row Row, IEnumerable<Cell> Cols);
    record PointWithCoords(Row Row, Cell Col, Point Point);
    record RowAndCol(Row Row, Cell Col);

    public Map(string[] input)
    {
        points = ParseInitialPoints(input)
            .ForEach(SetNeighbours)
            .Select(x => x.Point)
            .ToArray();
        basins = LowPoints()
            .Select(x => x.GetBasin())
            .ToArray();
    }

    private static PointWithCoords[] ParseInitialPoints(string[] input)
    {
        return input.Select(x => x.Parse())
            .Sandwich()
            .Select(x => new Row(x.index, x.previous, x.current, x.next))
            .Select(x => new RowWithCols(x, x.Current.Cast<int?>().Sandwich().Select(y => new Cell(y.index, y.previous, y.current, y.next))))
            .SelectMany(x => x.Cols, (y, col) => new RowAndCol(y.Row, col))
            .Select(x => new PointWithCoords(x.Row, x.Col, new Point(x.Row.Index, x.Col.Index, x.Col.Current!.Value)))
            .ToArray();
    }

    private PointWithCoords SetNeighbours(IList<PointWithCoords> data, PointWithCoords currentPoint)
    {
        var allPoints = data.Select(x => x.Point).ToList();
        currentPoint.Point.WithNeighbours(
            allPoints.PointAtCoordinate(currentPoint.Row.Index - 1, currentPoint.Col.Index),
            allPoints.PointAtCoordinate(currentPoint.Row.Index + 1, currentPoint.Col.Index),
            allPoints.PointAtCoordinate(currentPoint.Row.Index, currentPoint.Col.Index - 1),
            allPoints.PointAtCoordinate(currentPoint.Row.Index, currentPoint.Col.Index + 1)
        );
        return currentPoint;
    }

    public IReadOnlyCollection<Point> LowPoints() => points.Where(x => x.IsLowPoint).ToArray();
    public IReadOnlyCollection<Point> Points() => points;
    public IReadOnlyCollection<Basin> Basins() => basins;
}


namespace Puzzles.Day09LavaTubes;

public class Map
{
    private readonly Point[] points;
    private readonly Basin[] basins;

    // ReSharper disable NotAccessedPositionalProperty.Local
    record Cell(int Index, int? Left, int? Current, int? Right);
    record Row(int Index, int[]? Up, int[] Current, int[]? Down);
    // ReSharper restore NotAccessedPositionalProperty.Local
    record RowWithCols(Row Row, IEnumerable<Cell> Cols);
    record PointWithCoords(Row Row, Cell Col, Point Point);
    record RowAndCol(Row Row, Cell Col);

    public Map(string[] input)
    {
        var initialPoints = ParseInitialPoints(input);
        var lookup = Calculate2DLookup(initialPoints);
        points = initialPoints
            .ForEach((_, point) => SetNeighbours(point, lookup))
            .Select(x => x.Point)
            .ToArray();
        basins = LowPoints()
            .Select(x => x.GetBasin())
            .ToArray();
    }

    private static Point[,] Calculate2DLookup(PointWithCoords[] initialPoints)
    {
        var grid = new Point[initialPoints.Max(x => x.Row.Index + 1), initialPoints.Max(x => x.Col.Index + 1)];
        foreach (var point in initialPoints.Select(x => x.Point).ToList())
            grid[point.RowNumber, point.ColNumber] = point;
        return grid;
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

    private PointWithCoords SetNeighbours(
        PointWithCoords currentPoint,
        Point[,] lookup)
    {
        currentPoint.Point.WithNeighbours(
            lookup.PointAtCoordinate(currentPoint.Row.Index - 1, currentPoint.Col.Index),
            lookup.PointAtCoordinate(currentPoint.Row.Index + 1, currentPoint.Col.Index),
            lookup.PointAtCoordinate(currentPoint.Row.Index, currentPoint.Col.Index - 1),
            lookup.PointAtCoordinate(currentPoint.Row.Index, currentPoint.Col.Index + 1)
        );
        return currentPoint;
    }

    public IReadOnlyCollection<Point> LowPoints() => points.Where(x => x.IsLowPoint).ToArray();
    public IReadOnlyCollection<Point> Points() => points;
    public IReadOnlyCollection<Basin> Basins() => basins;
}

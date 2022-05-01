namespace Puzzles.Day09LavaTubes;

public class Map
{
    private readonly IReadOnlyCollection<Point> points;
    private readonly IReadOnlyCollection<Basin> basins;

    public Map(string[] input)
    {
        var parsed = input.Select(x => x.Parse())
            .Sandwich()
            .Select(x => new {row = x, col = x.current.Cast<int?>().Sandwich()})
            .SelectMany(x => x.col, (y, col) => new {y.row, col})
            .Select(x => new {x.row, x.col, point = new Point(x.row.index, x.col.index, x.col.current!.Value)})
            .ToArray();

        parsed.ForEach((data, currentPoint) =>
        {
            var allPoints = data.Select(x => x.point).ToList();
            currentPoint.point.WithNeighbours(
                allPoints.PointAtCoordinate(currentPoint.row.index - 1, currentPoint.col.index),
                allPoints.PointAtCoordinate(currentPoint.row.index + 1, currentPoint.col.index),
                allPoints.PointAtCoordinate(currentPoint.row.index, currentPoint.col.index - 1),
                allPoints.PointAtCoordinate(currentPoint.row.index, currentPoint.col.index + 1)
            );
        });
        points = parsed.Select(x => x.point).ToArray();
        basins = LowPoints().Select(x => x.GetBasin()).ToArray();
    }

    public IReadOnlyCollection<Point> LowPoints() => points.Where(x => x.IsLowPoint).ToArray();
    public IReadOnlyCollection<Point> Points() => points;
    public IReadOnlyCollection<Basin> Basins() => basins;
}

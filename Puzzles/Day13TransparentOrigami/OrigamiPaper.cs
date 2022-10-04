namespace Puzzles.Day13TransparentOrigami;

public class OrigamiPaper
{
    private readonly int[,] dotCoordinates;
    private readonly int width;
    private readonly int height;

    public OrigamiPaper(IReadOnlyCollection<Coordinate> dotCoordinates)
    {
        this.width = dotCoordinates.Max(x => x.X) + 1;
        this.height = dotCoordinates.Max(x => x.Y) + 1;
        this.dotCoordinates = new int[width, height];
        foreach (var dotCoordinate in dotCoordinates)
            this.dotCoordinates[dotCoordinate.X, dotCoordinate.Y] = 1;
        VisibleDotCount = dotCoordinates.Count;
    }
    
    private OrigamiPaper(IReadOnlyCollection<Coordinate> dotCoordinates, int width, int height)
    {
        this.dotCoordinates = new int[width, height];
        this.width = width;
        this.height = height;
        foreach (var dotCoordinate in dotCoordinates)
            this.dotCoordinates[dotCoordinate.X, dotCoordinate.Y] = 1;
        VisibleDotCount = dotCoordinates.Count;
    }

    public string[] Render()
    {
        var xAxis =  Enumerable.Range(0, width);
        var yAxis =  Enumerable.Range(0, height);
        return xAxis
            .SelectMany(_ => yAxis, (x, y) => new {X = x, Y = y})
            .Select(coord => new CoordWithChar(
                coord.X,
                coord.Y,
                HasDot(coord.X, coord.Y) ? '#' : '.'
            ))
            .GroupBy(coordWithChar => coordWithChar.Y)
            .Select(grouping => grouping.Aggregate("", (accum, coordWithChar) => $"{accum}{coordWithChar.Char}"))
            .ToArray();
    }

    public OrigamiPaper Fold(Fold fold)
    {
        switch (fold)
        {
            case FoldUp foldUp:
            {
                var topHalf = Enumerable.Range(1, foldUp.Y).Select(num => foldUp.Y - num);            
                var bottomHalf = Enumerable.Range(1, foldUp.Y).Select(num => foldUp.Y + num);
                var xAxis = Enumerable.Range(0, width);
                var coords = xAxis
                    .SelectMany(x => topHalf.Zip(bottomHalf).Select(zip => new { x, y1 = zip.First, y2 = zip.Second }))
                    .Where(zip => HasDot(zip.x, zip.y1) || HasDot(zip.x, zip.y2))
                    .Select(result => new Coordinate(result.x, result.y1))
                    .Distinct()
                    .ToArray();

                return new OrigamiPaper(coords, width, foldUp.Y);
            }
            case FoldLeft foldLeft:
            {
                var leftHalf = Enumerable.Range(1, foldLeft.X).Select(num => foldLeft.X - num);            
                var rightHalf = Enumerable.Range(1, foldLeft.X).Select(num => foldLeft.X + num);
                var yAxis = Enumerable.Range(0, height);
                var coords = yAxis
                    .SelectMany(y => leftHalf.Zip(rightHalf).Select(zip => new { x1 = zip.First, x2 = zip.Second, y}))
                    .Where(zip => HasDot(zip.x1, zip.y) || HasDot(zip.x2, zip.y))
                    .Select(result => new Coordinate(result.x1, result.y))
                    .Distinct()
                    .ToArray();

                return new OrigamiPaper(coords, foldLeft.X, height);
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(fold), "We only support folding up and left");
        }
    }
    
    public long VisibleDotCount { get; }

    private bool HasDot(int x, int y)
    {
        return dotCoordinates.GetUpperBound(0) >= x && 
               dotCoordinates.GetUpperBound(1) >= y &&
               dotCoordinates[x, y] == 1;
    }

    public OrigamiPaper Fold(Fold[] folds)
    {
        if (!folds.Any())
            return this;
        return Fold(folds[0]).Fold(folds[1..folds.Length]);
    }
}

// ReSharper disable once NotAccessedPositionalProperty.Global
internal record CoordWithChar(int X, int Y, char Char);

namespace Puzzles.Day13TransparentOrigami;

public class OrigamiPaper
{
    private readonly IReadOnlyCollection<Coordinate> dotCoordinates;
    private readonly int width;
    private readonly int height;

    public OrigamiPaper(IReadOnlyCollection<Coordinate> dotCoordinates)
    {
        this.dotCoordinates = dotCoordinates;
        this.width = dotCoordinates.Max(x => x.X) + 1;
        this.height = dotCoordinates.Max(x => x.Y) + 1; 
    }
    
    private OrigamiPaper(IReadOnlyCollection<Coordinate> dotCoordinates, int width, int height)
    {
        this.dotCoordinates = dotCoordinates;
        this.width = width;
        this.height = height;
    }

    public string[] Render()
    {
        var xAxis =  Enumerable.Range(0, width);
        var yAxis =  Enumerable.Range(0, height);
        return xAxis
            .SelectMany(x => yAxis, (x, y) => new {X = x, Y = y})
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
        if (fold is FoldUp foldUp)
        {
            var topHalf = Enumerable.Range(1, foldUp.Y).Select(num => foldUp.Y - num);            
            var bottomHalf = Enumerable.Range(1, foldUp.Y).Select(num => foldUp.Y + num);
            var xAxis = Enumerable.Range(0, width);
            var coords = xAxis
                .SelectMany(x => topHalf.Zip(bottomHalf).Select(zip => new { x = x, y1 = zip.First, y2 = zip.Second }))
                .Where(zip => HasDot(zip.x, zip.y1) || HasDot(zip.x, zip.y2))
                .Select(result => new Coordinate(result.x, result.y1))
                .Distinct()
                .ToArray();

            return new OrigamiPaper(coords, width, foldUp.Y);
        }
        
        if (fold is FoldLeft foldLeft)
        {
            var leftHalf = Enumerable.Range(1, foldLeft.X).Select(num => foldLeft.X - num);            
            var rightHalf = Enumerable.Range(1, foldLeft.X).Select(num => foldLeft.X + num);
            var yAxis = Enumerable.Range(0, height);
            var coords = yAxis
                .SelectMany(y => leftHalf.Zip(rightHalf).Select(zip => new { x1 = zip.First, x2 = zip.Second, y = y}))
                .Where(zip => HasDot(zip.x1, zip.y) || HasDot(zip.x2, zip.y))
                .Select(result => new Coordinate(result.x1, result.y))
                .Distinct()
                .ToArray();

            return new OrigamiPaper(coords, foldLeft.X, height);
        }

        throw new NotImplementedException();
    }
    
    public long VisibleDotCount() => dotCoordinates.Count();

    private bool HasDot(int x, int y) => dotCoordinates.Any(dotCoord => dotCoord.X == x && dotCoord.Y == y);

    public OrigamiPaper Fold(IEnumerable<Fold> folds)
    {
        if (!folds.Any())
            return this;
        return Fold(folds.First()).Fold(folds.Skip(1));
    }
}

internal record CoordWithChar(int X, int Y, char Char);

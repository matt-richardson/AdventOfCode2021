
using RT.Dijkstra;

namespace Puzzles.Day15Chiton;

public class RiskMap
{
    private readonly int width;
    private readonly int height;
    private readonly List<Cell> mapCells;

    public RiskMap(string[] inputData)
        : this(Parse(inputData))
    {
    }
    
    private RiskMap(IList<Cell> cells)
    {
        mapCells = new List<Cell>();
        mapCells.AddRange(cells);
        foreach (var cell in mapCells)
            cell.Connect(mapCells);
        Start = mapCells.Single(cell => cell.IsStart);
        width = mapCells.Max(cell => cell.X) + 1;
        height = mapCells.Max(cell => cell.Y) + 1;
    }

    private static IList<Cell> Parse(string[] inputData)
    {
        var cells = new List<Cell>();
        for(var y = 0; y < inputData.Length; y++)
        {
            var row = inputData[y];
            for(var x = 0; x < row.Length; x++)
            {
                var cell = new Cell(x, y, int.Parse(row[x].ToString()));
                cells.Add(cell);
            }
        }

        return cells;
    }

    private Cell Start { get; }

    public int CalculateLowestRiskPath()
    {
        var route = DijkstrasAlgorithm.Run (
            Start,
            0,
            (a, b) => a + b,
            out var lowestRiskPath);

        //Console.WriteLine($"{string.Join(", ", route)} ({lowestRiskPath} risk)");
        return lowestRiskPath;
    }

    /// <remarks>
    /// Your original map tile repeats to the right and downward; each time the tile repeats to the
    /// right or downward, all of its risk levels are 1 higher than the tile immediately up or left
    /// of it. However, risk levels above 9 wrap back around to 1.
    /// </remarks>
    public RiskMap Expand(int xMultiplier, int yMultiplier)
    {
        //this code is blurgh. Change to use enumerable.range
        var newCells = new List<Cell>();
        newCells.AddRange(mapCells);
        
        for (var xMultiple = 1; xMultiple < xMultiplier; xMultiple++)
        {
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var newCellX = xMultiple * width + x;
                    var prevCellX = newCellX - width;
                    var prevCell = newCells.Single(cell => cell.X == prevCellX && cell.Y == y);
                    var newCell = new Cell(newCellX, y, prevCell.Risk + 1);
                    newCells.Add(newCell);
                }
            }
        }
        for (var yMultiple = 1; yMultiple < yMultiplier; yMultiple++)
        {
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width * xMultiplier; x++)
                {
                    var newCellY = yMultiple * height + y;
                    var prevCellY = newCellY - height;
                    var prevCell = newCells.Single(cell => cell.X == x && cell.Y == prevCellY);
                    var newCell = new Cell(x, newCellY, prevCell.Risk + 1);
                    newCells.Add(newCell);
                }
            }
        }

        return new RiskMap(newCells);
    }

    public string[] Render()
    {
        var xAxis =  Enumerable.Range(0, width + 1);
        var yAxis =  Enumerable.Range(0, height + 1);
        return xAxis
            .SelectMany(_ => yAxis, (x, y) => new {X = x, Y = y})
            .SelectMany(coord => mapCells.Where(cell => cell.X == coord.X && cell.Y == coord.Y))
            .GroupBy(cell => cell.Y)
            .Select(grouping => grouping.Aggregate("", (accum, cell) => $"{accum}{cell.Risk}"))
            .ToArray();
    }
}


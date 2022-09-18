
using RT.Dijkstra;

namespace Puzzles.Day15Chiton;

public class RiskMap
{
    private readonly int width;
    private readonly int height;
    private readonly Cell[,] mapCells;

    public RiskMap(string[] inputData)
        : this(Parse(inputData))
    {
    }
    
    private RiskMap(Cell[,] cells)
    {
        mapCells = cells;
        foreach (var cell in cells)
            cell.Connect(cells);
        Start = mapCells[0,0];
        width = cells.GetUpperBound(0) + 1;
        height = cells.GetUpperBound(1) + 1;
    }

    private static Cell[,] Parse(string[] inputData)
    {
        var cells = new Cell[inputData[0].Length, inputData.Length];
        for(var y = 0; y < inputData.Length; y++)
        {
            var row = inputData[y];
            for(var x = 0; x < row.Length; x++)
            {
                var cell = new Cell(x, y, int.Parse(row[x].ToString()));
                cells[x,y] = cell;
            }
        }

        return cells;
    }

    private Cell Start { get; }

    public int CalculateLowestRiskPath()
    {
        DijkstrasAlgorithm.Run (
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
        var newCells = new Cell[width * xMultiplier, height * yMultiplier];
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                newCells[x,y] = mapCells[x, y];
            }
        }

        for (var xMultiple = 1; xMultiple < xMultiplier; xMultiple++)
        {
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var newCellX = xMultiple * width + x;
                    var prevCellX = newCellX - width;
                    var prevCell = newCells[prevCellX, y];
                    var newCell = new Cell(newCellX, y, prevCell.Risk + 1);
                    newCells[newCellX, y] = newCell;
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
                    var prevCell = newCells[x, prevCellY];
                    var newCell = new Cell(x, newCellY, prevCell.Risk + 1);
                    newCells[x, newCellY] = newCell;
                }
            }
        }
        
        return new RiskMap(newCells);
    }

    public string[] Render()
    {
        var xAxis =  Enumerable.Range(0, width);
        var yAxis =  Enumerable.Range(0, height);
        return xAxis
            .SelectMany(_ => yAxis, (x, y) => new {X = x, Y = y})
            .Select(coord => mapCells[coord.X, coord.Y])
            .GroupBy(cell => cell.Y)
            .Select(grouping => grouping.Aggregate("", (accum, cell) => $"{accum}{cell.Risk}"))
            .ToArray();
    }
}


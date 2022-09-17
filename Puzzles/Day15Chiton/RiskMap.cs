
using RT.Dijkstra;

namespace Puzzles.Day15Chiton;

public class RiskMap
{
    public RiskMap(string[] inputData)
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
        foreach (var cell in cells)
        {
            cell.Connect(cells);
        }
        Start = cells.Single(cell => cell.IsStart);
    }

    private Cell Start { get; }

    public int CalculateLowestRiskPath()
    {
        var route = DijkstrasAlgorithm.Run (
            Start,
            0,
            (a, b) => a + b,
            out var lowestRiskPath);

        Console.WriteLine($"{string.Join(", ", route)} ({lowestRiskPath} risk)");
        return lowestRiskPath;
    }
}


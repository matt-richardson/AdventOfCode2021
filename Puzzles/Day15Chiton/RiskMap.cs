
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
        var shortestPathTracker = new PathTracker(Start);

        foreach(var path in FindPaths(shortestPathTracker))
        {
            shortestPathTracker.Track(path);
        }
        
        return shortestPathTracker.RiskOfShortestPath;
    }

    public IEnumerable<Path> FindPaths(PathTracker shortestPathTracker)
    {
        var visitTracker = new VisitTracker();
        foreach (var cell in FindPaths(Start, shortestPathTracker, visitTracker))
        {
            Console.WriteLine("FindPaths(PathTracker): " + cell);
            yield return new Path(cell, Start);
        }
        //return Enumerable.Empty<Path>();
    }

    public IEnumerable<Path> FindPaths(Cell cell, PathTracker shortestPathTracker, VisitTracker visitTracker)
    {
        visitTracker.Visit(cell);
        foreach (var connectedCell in cell.ConnectedCells.OrderBy(x => x.Risk).Where(x => visitTracker.CanVisit(x)))
        {
            if (connectedCell.IsEnd)
            {
                yield return new Path(connectedCell);
            }
            else
            {
                var paths = FindPaths(connectedCell, shortestPathTracker, visitTracker.Clone()).OrderBy(x => x.Risk);
                foreach (var path in paths)
                {
                    var newPath = new Path(path, connectedCell);
                    if (newPath.RevistsItself)
                        Console.WriteLine("Path " + path + " revisits itself - not a viable soln");
                    else if (newPath.Risk > shortestPathTracker.RiskOfShortestPath)
                    {
                        Console.WriteLine("Path " + path + " has a higher risk than the lowest risk " + shortestPathTracker.RiskOfShortestPath);
                        break;
                    }
                    else if (newPath.IsComplete)
                        Console.WriteLine("Path " + path + " is complete with total risk " + path.Risk);
                    else
                       yield return newPath;
                }   
            }
        }
    }
}


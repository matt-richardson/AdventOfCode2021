namespace Puzzles.Day15Chiton;

public class PathTracker 
{
    private Path shortestPath;
    
    public PathTracker(Cell start)
    {
        var stack = new Stack<Cell>();
        stack.Push(start.Right!);
        while (stack.Peek().Right != null)
            stack.Push(stack.Peek().Right!);
        while (stack.Peek().Down != null)
            stack.Push(stack.Peek().Down!);
        var path = new Path(stack.Pop());
        while (stack.Any())
            path = new Path(path, stack.Pop());

        shortestPath = path;
        Console.WriteLine("Naive path is: " + path);
        Console.WriteLine("Naive path risk is: " + path.Risk);
    }

    public bool IsPathViable(Path path)
    {
        if (path.Risk < shortestPath.Risk)
        {
            Console.WriteLine("Path " + path + " is shorter than " + shortestPath);
            return true;
        }
        return false;
    }

    public void Track(Path path)
    {
        if (!path.IsComplete)
            return;
        else if (shortestPath.Risk > path.Risk)
            shortestPath = path;
    }
    
    public int RiskOfShortestPath => shortestPath!.Risk;
}
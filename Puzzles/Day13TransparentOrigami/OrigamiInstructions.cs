namespace Puzzles.Day13TransparentOrigami;

public class OrigamiInstructions
{
    public OrigamiInstructions(string[] inputData)
    {
        var coordinates = inputData
            .TakeWhile(x => !string.IsNullOrEmpty(x))
            .Select(x => x.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
            .Select(x => new Coordinate(x[0], x[1]))
            .ToArray();

        Folds = inputData
            .Skip(coordinates.Length)
            .Where(x => x.StartsWith("fold along"))
            .Select(x => new
            {
                Axis = x[11],
                Line = int.Parse(x[13..])
            })
            .Select(x => x.Axis == 'x' ? (Fold) new FoldLeft(x.Line) : new FoldUp(x.Line))
            .ToArray();
        
        Paper = new OrigamiPaper(coordinates);
    }

    public OrigamiPaper Paper { get; }
    public IReadOnlyCollection<Fold> Folds { get; }


}

public record Coordinate(int X, int Y);
public abstract record Fold;
public record FoldUp(int Y) : Fold;
public record FoldLeft(int X) : Fold;

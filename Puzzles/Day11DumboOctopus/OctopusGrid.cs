namespace Puzzles.Day11DumboOctopus;

public class OctopusGrid
{
    private readonly IReadOnlyCollection<Octopus> octopii;

    record Cell(int Index, int? Left, int? Current, int? Right);
    record Row(int Index, int[]? Up, int[] Current, int[]? Down);
    record RowWithCols(Row Row, IEnumerable<Cell> Cols);
    record OctopusWithCoords(Row Row, Cell Col, Octopus Octopus);
    record RowAndCol(Row Row, Cell Col);

    public long FlashCount { get; private set; }
    public long StepCount { get; private set; }
    public bool IsSynchronized => octopii.All(x => x.EnergyLevel == 0);

    public OctopusGrid(string[] input)
    {
        octopii = ParseInitialOctopii(input)
            .ForEach(SetNeighbours)
            .Select(x => x.Octopus)
            .ForEach(SubscribeToOnFlash)
            .ToArray();
    }

    private Octopus SubscribeToOnFlash(IList<Octopus> list, Octopus octopus)
    {
        octopus.OnFlash += (sender, args) => FlashCount++;
        return octopus;
    }

    public void Step(int stepCount)
    {
        for (var i = 0; i < stepCount; i++)
            Step();
    }

    public void Step()
    {
        StepCount++;
        foreach (var octopus in octopii) octopus.Step();
        foreach (var octopus in octopii) octopus.FlashIfRequired();
        foreach (var octopus in octopii) octopus.ResetIfRequired();
    }

    public void StepUntilSynchronized()
    {
        do
        {
            Step();
        } while (!IsSynchronized);
    }
    
    private static OctopusWithCoords[] ParseInitialOctopii(string[] input)
    {
        return input.Select(x => x.Parse())
            .Sandwich()
            .Select(x => new Row(x.index, x.previous, x.current, x.next))
            .Select(x => new RowWithCols(x, x.Current.Cast<int?>().Sandwich().Select(y => new Cell(y.index, y.previous, y.current, y.next))))
            .SelectMany(x => x.Cols, (y, col) => new RowAndCol(y.Row, col))
            .Select(x => new OctopusWithCoords(x.Row, x.Col, new Octopus(x.Row.Index, x.Col.Index, x.Col.Current!.Value)))
            .ToArray();
    }

    private OctopusWithCoords SetNeighbours(IList<OctopusWithCoords> data, OctopusWithCoords currentOctopus)
    {
        var allOctopii = data.Select(x => x.Octopus).ToList();
        currentOctopus.Octopus.WithNeighbours(
            allOctopii.OctopusAtCoordinate(currentOctopus.Row.Index - 1, currentOctopus.Col.Index - 1),
            allOctopii.OctopusAtCoordinate(currentOctopus.Row.Index - 1, currentOctopus.Col.Index),
            allOctopii.OctopusAtCoordinate(currentOctopus.Row.Index - 1, currentOctopus.Col.Index + 1),
            allOctopii.OctopusAtCoordinate(currentOctopus.Row.Index, currentOctopus.Col.Index - 1),
            allOctopii.OctopusAtCoordinate(currentOctopus.Row.Index, currentOctopus.Col.Index + 1),
            allOctopii.OctopusAtCoordinate(currentOctopus.Row.Index + 1, currentOctopus.Col.Index - 1),
            allOctopii.OctopusAtCoordinate(currentOctopus.Row.Index + 1, currentOctopus.Col.Index),
            allOctopii.OctopusAtCoordinate(currentOctopus.Row.Index + 1, currentOctopus.Col.Index + 1)
        );
        return currentOctopus;
    }

    public string[] Render()
    {
        return octopii.GroupBy(x => x.RowNumber)
            .Select(grouping => string.Join("", grouping.OrderBy(x => x.ColNumber).Select(x => x.EnergyLevel)))
            .ToArray();
    }
}

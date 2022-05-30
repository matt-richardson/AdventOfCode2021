namespace Puzzles.Day12PassagePathing;

public record CaveConnection(string StartingCave, string EndingCave)
{
    public bool ConnectsTo(Cave cave) => StartingCave == cave.Name || EndingCave == cave.Name;
}

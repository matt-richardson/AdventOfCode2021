namespace Puzzles.Day12PassagePathing;

public class CaveSystem
{
    private readonly Cave[] caves;

    public CaveSystem(CaveConnection[] caveConnections)
    {
        caves = caveConnections
            .Select(x => x.StartingCave)
            .Concat(caveConnections.Select(x => x.EndingCave))
            .Distinct()
            .Select(x => new Cave(x))
            .ToArray();
        foreach (var cave in caves)
            cave.Connect(caveConnections.Where(connection => connection.ConnectsTo(cave)), caves);
    }

    public Cave Start => caves.Single(x => x.Name == "start");
    public Cave End => caves.Single(x => x.Name == "end");
}

namespace Puzzles.Day12PassagePathing;

public static class Day12ExtensionMethods
{
    public static CaveConnection Parse(this string input)
    {
        var parts = input
            .Split("-", StringSplitOptions.RemoveEmptyEntries);
        return new CaveConnection(parts[0], parts[1]);
    }
    
    public static CaveSystem Parse(this string[] input)
    {
        var caveConnections = input.Select(x => x.Parse()).ToArray();

        return new CaveSystem(caveConnections);
    }
}

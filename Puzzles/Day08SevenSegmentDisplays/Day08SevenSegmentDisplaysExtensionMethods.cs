namespace Puzzles.Day08SevenSegmentDisplays;

public static class Day08SevenSegmentDisplaysExtensionMethods
{
    public static (string[] signals, string[] displays)[] Parse(this string[] input)
    {
        return input.Select(Parse).ToArray();
    }

    public static (string[] signals, string[] displays) Parse(this string input)
    {
        var split = input.Split(" | ");
        var signals = split[0].Split(" ").Select(Sort).ToArray();
        var displays = split[1].Split(" ").Select(Sort).ToArray();
        return (signals, displays);
    }

    private static string Sort(this string input)
    {
        return string.Join("", input.ToCharArray().OrderBy(y => y));
    }
}

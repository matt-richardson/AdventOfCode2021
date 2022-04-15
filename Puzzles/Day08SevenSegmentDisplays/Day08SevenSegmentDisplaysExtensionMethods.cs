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
        var signals = split[0].Split(" ");
        var displays = split[1].Split(" ");
        return (signals, displays);
    }
}
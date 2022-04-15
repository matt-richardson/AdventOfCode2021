
using System.Diagnostics;

namespace Puzzles.Day08SevenSegmentDisplays;

public class Day08SevenSegmentDisplays : IPuzzle
{
    public (object answer1, object answer2) Calculate()
    {
        var input = Helpers.ReadInputData(nameof(Day08SevenSegmentDisplays));

        return (
            CalculatePart1(input),
            CalculatePart2(input)
        );
    }

    public static long CalculatePart1(string[] input)
    {
        var parsed = input.Parse();
        return parsed.Sum(x => x.displays.Count(display => display.Length is 2 or 3 or 4 or 7));
    }

    public static long CalculatePart2(string[] input)
    {
        return input
            .Select(x => x.Parse())
            .Select(x => new
            {
                x.signals,
                x.displays,
                mappings = ResolveSignalsToNumbers(x.signals)
            })
            .Select(x => GetDisplayReadout(x.mappings, x.displays))
            .Sum();
    }

    public static string[] ResolveSignalsToNumbers(string[] signals)
    {
        var results = new string[10]; //0-9
        foreach (var signal in SortSignals(signals))
        {
            var position = DetermineNumber(signal, results);
            results[position] = signal;
        }

        return results;
    }

    public static int GetDisplayReadout(string[] signals, string[] resolvedSignals)
    {
        var resultAsString = resolvedSignals.Aggregate("", (prev, curr) => $"{prev}{FindSignal(signals, curr)}");
        return int.Parse(resultAsString);
    }

    private static int FindSignal(string[] signals, string display)
    {
        var index = Array.FindIndex(signals, x => x == display);
        Debug.Assert(index > -1, (string?) $"unexpectedly unable to find {display} in [{string.Join(",", signals)}]");
        return index;
    }

    private static int DetermineNumber(string signal, string[] results)
    {
        return signal.Length switch
        {
            2 => 1,
            3 => 7,
            4 => 4,
            7 => 8,
            6 when !Contains(signal, results[1]) => 6,
            6 when Contains(signal, results[4]) => 9,
            6 => 0,
            5 when Contains(signal, results[1]) => 3,
            5 when ContainsLowerLeftSignal(signal, results[9]) => 2,
            5 => 5,
            _ => throw new IndexOutOfRangeException("Unexpected signal length")
        };
    }

    private static IEnumerable<string> SortSignals(string[] signals)
    {
        //order is important - we need some answers to figure out others
        int GetPriority(string x) => x.Length switch
            {
                2 => 1,
                3 => 2,
                4 => 3,
                7 => 4,
                6 => 5,
                _ => 6
            };

        return signals.Select(x => new
            {
                signals = x,
                length = x.Length,
                priority = GetPriority(x)
            })
            .OrderBy(x => x.priority)
            .Select(x => x.signals);
    }

    private static bool Contains(string signals, string result)
    {
        var s = signals.ToCharArray();
        return result.ToCharArray().All(x => s.Contains(x));
    }

    private static bool ContainsLowerLeftSignal(string signals, string result9)
    {
        var lowerLeftSignal = new[] {'a', 'b', 'c', 'd', 'e', 'f', 'g'}
            .Except(result9.ToCharArray())
            .Single();
        return signals.Contains(lowerLeftSignal);
    }
}

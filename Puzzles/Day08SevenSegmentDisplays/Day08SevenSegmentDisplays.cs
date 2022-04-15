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
        var parsed = input.Parse();

        foreach(var row in parsed)
        {
            var display = new SevenSegmentDisplay();
            var easyNumbers = row.signals
                .Where(display => display.Length is 2 or 3 or 4)
                .OrderBy(display => display.Length);
            foreach (var number in easyNumbers)
                display.TryApply(number);

            var hardNumbers = row.signals
                .Where(display => display.Length != 2 && display.Length != 3 && display.Length != 4)
                .OrderBy(display => display.Length);
            // foreach (var number in hardNumbers)
            //     display.TryApply(number);
            display.ResolveRemainingNumbers(hardNumbers);
        }

        return 1;
    }
}

[DebuggerDisplay("{Name}: {ToString()}")]
class Segment
{
    private char[] potentialConnections;

    public Segment(string name)
    {
        this.Name = name;
        this.potentialConnections = new[] {'a', 'b', 'c', 'd', 'e', 'f', 'g'};
    }

    public string Name { get; }

    public void FilterTo(string number)
    {
        this.potentialConnections = this.potentialConnections.Where(x => number.ToCharArray().Contains(x)).ToArray();
    }

    public void FilterOut(string number)
    {
        this.potentialConnections = this.potentialConnections.Except(number.ToCharArray()).ToArray();
    }

    public override string ToString()
    {
        char GetCharOrBlank(char letter) => potentialConnections.Contains(letter) ? letter : '_';

        return Enumerable.Range('a', 'g' - 'a' + 1)
            .Aggregate("", (prev, curr) => $"{prev}{GetCharOrBlank((char) curr)}")
            .ToString();
    }
}

[DebuggerDisplay("{Name, nq}")]
class Segments
{
    public string Name { get; }
    private readonly Segment[] segments;

    public Segments(string name, params Segment[] segments)
    {
        Name = name;
        this.segments = segments;
    }

    public int Length => segments.Length;

    public void FilterIn(string number)
    {
        foreach(var segment in segments)
            segment.FilterTo(number);
    }

    public void FilterOut(string number)
    {
        foreach(var segment in segments)
            segment.FilterOut(number);
    }

    // public override string ToString()
    // {
    //     return segments.
    // }
    public void FilterOut(Segments potentialNumber, string number)
    {
        var otherSegments = segments.Where(s => !potentialNumber.segments.Contains(s));
        foreach (var s in otherSegments)
            s.FilterOut(number);
    }
}

public class SevenSegmentDisplay
{
    readonly Segment segmentTop = new("top");
    readonly Segment segmentMiddle = new("middle");
    readonly Segment segmentBottom = new("bottom");
    readonly Segment segmentUpperLeft = new("upper left");
    readonly Segment segmentUpperRight = new("upper right");
    readonly Segment segmentLowerLeft = new("lower left");
    readonly Segment segmentLowerRight = new("lower right");

    Segments numberOne, numberTwo, numberThree, numberFour, numberFive, numberSix, numberSeven, numberEight, numberNine, numberZero, allSegments;
    private readonly Segments[] allNumbers;

    public SevenSegmentDisplay()
    {
        numberOne = new Segments("one", segmentUpperRight, segmentLowerRight);
        numberTwo = new Segments("two", segmentTop, segmentUpperRight, segmentMiddle, segmentLowerLeft, segmentBottom);
        numberThree = new Segments("three", segmentTop, segmentUpperRight, segmentMiddle, segmentLowerRight, segmentBottom);
        numberFour = new Segments("four", segmentUpperLeft, segmentMiddle, segmentUpperRight, segmentLowerRight);
        numberFive = new Segments("five", segmentTop, segmentUpperLeft, segmentMiddle, segmentLowerRight, segmentBottom);
        numberSix = new Segments("fix", segmentTop, segmentUpperLeft, segmentMiddle, segmentLowerRight, segmentBottom, segmentLowerLeft);
        numberSeven = new Segments("seven", segmentTop, segmentUpperRight, segmentLowerRight);
        numberEight = new Segments("eight", segmentTop, segmentUpperRight, segmentMiddle, segmentLowerLeft, segmentBottom, segmentLowerRight, segmentUpperLeft);
        numberNine = new Segments("nine", segmentTop, segmentUpperLeft, segmentMiddle, segmentUpperRight, segmentLowerRight, segmentBottom);
        numberZero = new Segments("zero", segmentTop, segmentUpperRight, segmentLowerRight, segmentBottom, segmentLowerLeft, segmentUpperLeft);

        allSegments = new Segments("all", segmentTop, segmentUpperRight, segmentMiddle, segmentLowerLeft, segmentBottom, segmentLowerRight, segmentUpperLeft);

        allNumbers = new[] {numberOne, numberTwo, numberThree, numberFour, numberFive, numberSix, numberSeven, numberEight, numberNine, numberZero};
    }

    public void TryApply(string number)
    {
        foreach (var potentialNumber in allNumbers)
        {
            if (potentialNumber.Length == number.Length)
            {
                potentialNumber.FilterIn(number);
                allSegments.FilterOut(potentialNumber, number);
            }
        }
    }

    public void ResolveRemainingNumbers(IOrderedEnumerable<string> orderedEnumerable)
    {
        var unresolvedNumbers = new List<string>(orderedEnumerable.Where(x => x.Length != 7));





        Console.WriteLine(this.segmentBottom.ToString());
        // while (true)
        // {
        //     foreach(var number in allNumbers)
        //
        // }
    }
}

public static class Day08SevenSegmentDisplaysExtensionMethods
{
    public static (string[] signals, string[] displays)[] Parse(this string[] input)
    {
        return input
            .Select(x =>
            {
                var split = x.Split(" | ");
                return (signals: split[0], displays: split[1]);
            }).Select(x =>
            {
                var signals = x.signals.Split(" ");
                var displays = x.displays.Split(" ");
                return (signals, displays);
            })
            .ToArray();
    }
}

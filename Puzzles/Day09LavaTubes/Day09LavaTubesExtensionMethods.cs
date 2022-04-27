using System.Diagnostics;

namespace Puzzles.Day09LavaTubes;

public static class Day09LavaTubesExtensionMethods
{
    public static IEnumerable<Point> Parse(this string[] input)
    {
        var data = input.Select(Parse).ToArray();

        foreach (var (rowNumber, rowUp, rowCurrent, rowDown) in data.Loop())
        {
            foreach (var (colNumber, colLeft, colCurrent, colRight) in rowCurrent.Loop())
            {
                yield return new Point(
                    rowNumber,
                    colNumber,
                    colCurrent,
                    rowUp?[colNumber],
                    rowDown?[colNumber],
                    colLeft,
                    colRight
                );
            }     
        }
    }

    private static IEnumerable<(int, T?, T, T?)> Loop<T>(this T[] data) 
    {
        var lowerBound = data.GetLowerBound(0);
        var upperBound = data.GetUpperBound(0);
        for (var index = lowerBound; index <= upperBound; index++)
        {
            var previous = index == lowerBound ? default : data[index - 1];
            var current = data[index];
            var next = index == upperBound ? default : data[index + 1];
            yield return (index, previous, current, next);
        }
    }

    public static int[] Parse(this string input)
    {
        return input.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
    }
}

[DebuggerDisplay("({RowNumber},{ColNumber}): Height {Height}, Risk {RiskLevel}")]
public record Point(int RowNumber, int ColNumber, int Height, int? Up, int? Down, int? Left, int? Right)
{
    public bool IsLowPoint =>
        IsLowerThanPointUp &&
        IsLowerThanPointDown &&
        IsLowerThanPointLeft &&
        IsLowerThanPointRight;

    public int RiskLevel => Height + 1;

    private bool IsLowerThanPointUp => Up == null || Up > Height;
    private bool IsLowerThanPointDown => Down == null || Down > Height;
    private bool IsLowerThanPointLeft => Left == null || Left > Height;
    private bool IsLowerThanPointRight => Right == null || Right > Height;
};

